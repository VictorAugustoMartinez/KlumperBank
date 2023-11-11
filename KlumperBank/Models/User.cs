
namespace KlumperBank.Models
{
    public class User
    {
        public int Id { get; }
        public string Name { get;  set; }
        public string Password { get; set; }
        public int Balance { get;  set; }
        public string Role { get; set; } 
    }

}
