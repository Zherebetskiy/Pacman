using PacmanWeb.Validation;

namespace PacmanWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        [UserName]
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
