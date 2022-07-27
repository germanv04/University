namespace UniversityWebAPI.Models
{
    public class UserTokens
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public string UserName { get; set; }
        public TimeSpan ValidezDelToken { get; set; } 
        //para verificar la validad del token y no haya caducado por tiempo u otras cosas
        public string RefreshToken { get; set; }
        public string EmailId { get; set; }
        public Guid Guid { get; set; } //Id de cada token que se van creando
        public DateTime ExpiredTime { get; set; }
    }
}
