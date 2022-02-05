namespace Intro.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public bool EmailIsConfirmed { get; set; }

        public byte[] PasswordHash { get; set; }
    }
}
