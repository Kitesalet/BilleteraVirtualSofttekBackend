namespace BilleteraVirtualSofttekBack.Models.HelperClasses
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public int ExpirationMinutes { get; set; }
        public string Subject { get; set; }
        public string Issuer { get; set; }

    }
}
