namespace UniversityWebAPI.Models
{
    public class UserTokens
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public TimeSpan Validity { get; set; }
        public string RefreshToken { get; set; }
        public string EmailId { get; set; }
        public Guid Guid { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
