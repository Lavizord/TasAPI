namespace ConfigurationPOCO
{
    public class DatabaseConfiguration
    {
        public string Server { get; set; }
        public string UserId { get; set;}

        public string Password { get; set; }

        public string DatabaseName { get; set; }
        public bool TrustedConnection { get; set; }
        public bool TrustServerCertificate { get; set; }
        public bool MultipleActiveResultSets { get; set; }

    }
}