using System.Collections.Generic;
using System.Linq;
using PacmanWeb.DAL;
using PacmanWeb.Models;

namespace PacmanWeb.BusinessLogic
{
    public class UserService : IUserService
    {
        public readonly IUnitOfWork data;

        public UserService(IUnitOfWork data)
        {
            this.data = data;
        }

        public void Create(User user)
        {            
            data.Set<User>().Create(user);
            data.Save();
        }

        public IEnumerable<User> Get()
        {
            return data.Set<User>().Get().OrderByDescending(user=> user.Score);
        }

        public IEnumerable<User> GetTopTen()
        {
            return data.Set<User>().Get().OrderByDescending(user=>user.Score).Take(10);
        }

    }
}
