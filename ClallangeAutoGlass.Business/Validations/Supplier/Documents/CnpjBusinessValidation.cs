using System;
namespace ClallangeAutoGlass.Business.Validations.Documents
{
	public class CnpjBusinessValidation
    {
        public const int LENGTH_CNPJ = 14;

        public static bool Validate(string cnpj)
        {
            var cnpjOnlyNumbers = Utils.OnlyNumbers(cnpj);

            if (!Utils.IsLengthValid(value: cnpj, targetLength: LENGTH_CNPJ)) return false;

            return true;
        }
    }
}

