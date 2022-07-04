namespace UniversityWebAPI.Models
{
    public class JWTSettings
    {
        public bool ValidateIssuerSigninKey { get; set; }
        public string? IssuerSigninKey { get; set; }

        public bool ValidateIssuer { get; set; }
        public string? Issuer { get; set; }

        public bool ValidateAudience { get; set; }
        public string? validAudience { get; set; }

        public bool RequireExperationTime { get; set; }
        public bool ValidateLifeTime { get; set; }
    }
}
