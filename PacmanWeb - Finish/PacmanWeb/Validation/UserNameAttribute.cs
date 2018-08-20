using PacmanWeb.BusinessLogic;
using PacmanWeb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PacmanWeb.Validation
{
    public class UserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IUserService userService =(IUserService)validationContext.GetService(typeof(IUserService));

            var topTen = userService.GetTopTen();
            User user = (User)validationContext.ObjectInstance;

            if (user.Score > topTen.LastOrDefault().Score && !IsNameValid(topTen, user.Name))
            {
                return new ValidationResult($"{ user.Name } is already exist in top ten results. Please, enter the unique one.");
            }

            return ValidationResult.Success;
        }


        bool IsNameValid(IEnumerable<User> topTen, string name)
        {
            foreach (var user in topTen)
            {
                if (user.Name == name)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
