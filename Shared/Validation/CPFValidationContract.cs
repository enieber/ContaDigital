namespace Shared.FluentValidator.Validation
{
    public partial class ValidationContract : Notifiable
    {
		public ValidationContract ValidCpf(string cpf, string property, string message)
		{
			if (string.IsNullOrWhiteSpace(cpf))
            {
				AddNotification(property, message);
				return this;
			}

			int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string _cpf;
			string dig;
			int sum;
			int rest;

			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");

			if (cpf.Length != 11)
				 AddNotification(property, message);

			_cpf = cpf.Substring(0, 9);
			sum = 0;

			for (int i = 0; i < 9; i++)
				sum += int.Parse(_cpf[i].ToString()) * multiplier1[i];

			rest = sum % 11;

			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;

			dig = rest.ToString();
			_cpf = _cpf + dig;
			sum = 0;

			for (int i = 0; i < 10; i++)
				sum += int.Parse(_cpf[i].ToString()) * multiplier2[i];

			rest = sum % 11;

			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;

			dig = dig + rest.ToString();

			if (!cpf.EndsWith(dig))
				AddNotification(property, message);

			return this;
		}
	}
}
