namespace CirculaBem.Service.Domain.User.DTO
{
    public class UserDTO
    {
        private string _registrationNumber = string.Empty;
        public string RegistrationNumber { get => _registrationNumber; set => _registrationNumber = MaskString(value); }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        private string MaskString(string input)
        {
            // Check if the input string has at least 4 characters
            if (input.Length < 4)
                throw new ArgumentException("Input string must have at least 4 characters.");

            // Replace characters between the third and second-to-last characters with asterisks
            return input.Substring(0, 2) + new string('*', input.Length - 4) + input.Substring(input.Length - 2);
        }
    }
}
