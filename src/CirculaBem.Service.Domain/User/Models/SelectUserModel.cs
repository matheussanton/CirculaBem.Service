using CirculaBem.Service.Domain.Address.Models;

namespace CirculaBem.Service.Domain.User.Models
{
    public class SelectUserModel
    {
        private string _registrationNumber = string.Empty;
        public string MaskedRegistrationNumber { get => _registrationNumber; set => _registrationNumber = MaskString(value); }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public SelectAddress Address { get; set; }

        private string MaskString(string input)
        {
            if (input.Length < 4)
                throw new ArgumentException("Input string must have at least 4 characters.");

            return input.Substring(0, 2) + new string('*', input.Length - 4) + input.Substring(input.Length - 2);
        }
    }
}
