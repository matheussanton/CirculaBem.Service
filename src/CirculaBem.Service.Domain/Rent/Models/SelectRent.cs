namespace CirculaBem.Service.Domain.Rent.Models
{
    public class SelectRent
    {
        public Guid Id { get; set; }
        public string UserRegistrationNumber { get; set; }
        public Guid ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
