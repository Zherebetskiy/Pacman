using PacmanWeb.Models;
using System.Collections.Generic;

namespace PacmanWeb.BusinessLogic
{
    public interface IUserService
    {
        IEnumerable<User> Get();

        void Create(User user);

        IEnumerable<User> GetTopTen();
    }
}
