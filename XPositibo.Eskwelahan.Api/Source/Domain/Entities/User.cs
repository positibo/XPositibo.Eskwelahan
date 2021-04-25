namespace XPositibo.Eskwelahan.Api.Source.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; }

        public virtual Member Member { get; set; }
    }
}
