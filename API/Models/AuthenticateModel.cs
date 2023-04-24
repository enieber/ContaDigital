using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AuthenticateModel
    {
        /// <summary>
        /// Login de acesso
        /// </summary>
        /// <value></value>
        [Required]
        public string Cpf { get; set; }

        /// <summary>
        /// Senha de acesso
        /// </summary>
        /// <value></value>
        [Required]
        public string Password { get; set; }
    }
}
