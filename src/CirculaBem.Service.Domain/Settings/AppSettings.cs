namespace CirculaBem.Service.Domain.Settings
{
    public class AppSettings
    {
        public string PostgreSQLConnectionString { get; set; }
        public string JwtSecretKey { get; set; }
        public string EncryptionKey { get; set; }
    }
}
