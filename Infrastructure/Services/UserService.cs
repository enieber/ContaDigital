using Domain.Entities;
using Domain.Queries;
using Domain.Repositories;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IConfiguration _config;

        public UserService(IUserRepository repository, IUserAccountRepository userAccountRepository, IConfiguration config)
        {
            _repository = repository;
            _userAccountRepository = userAccountRepository;
            _config = config;
        }

        public QueryUser GetUserId(Guid idUser)
        {
            return _repository.GetUserId(idUser);
        }

        public string Authenticate(string cpf, string password)
        {
            var user = _repository.GetUserByCpf(cpf);

            // user and password invalid
            if (user == null || password != user.Password)
                return "Usuário ou senha inválidos.";

            // login sucess, get token jwt
            var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var _issuer = _config["Jwt:Issuer"];
            var _audience = _config["Jwt:Audience"];

            var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                    new Claim(ClaimTypes.Name, user.Name)
                };

            var tokeOptions = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            ///Update Last Access
            var queryUserAccount = GetAccountByCPF(cpf);
            UpdateLastAccess(queryUserAccount);

            return tokenString;
        }

        private void UpdateLastAccess(QueryUserAccount queryUserAccount)
        {
             _userAccountRepository.UpdateLastAccess(queryUserAccount);
        }

        public QueryUserAccount GetAccountByCPF(string cpf)
        {
            return _userAccountRepository.GetAccountByCPF(cpf);
        }

    }
}
