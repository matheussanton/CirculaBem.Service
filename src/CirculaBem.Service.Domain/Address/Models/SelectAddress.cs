namespace CirculaBem.Service.Domain.Address.Models
{
    public class SelectAddress
    {
        public string UserRegistrationNumber { get; set; }
        public string Cep { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Street { get; set; }
        public short Number { get; set; }
        public string Complement { get; set; }
    }
}
