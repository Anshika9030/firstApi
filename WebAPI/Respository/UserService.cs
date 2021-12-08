using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contract.Request;
using WebAPI.Models;

namespace WebAPI.Respository
{
    public class UserService : IUsers
    {
        private List<Users> users;
        public UserService()
        {
            users = new List<Users>()
            {
                new Users(){Name="anshika",Email="anshu@gmail.com",Password="12345"},
                new Users(){Name="nikhil",Email="nikki@gmail.com",Password="12121"},
                new Users(){Name="monu",Email="monu@gmail.com",Password="123456"}
            };
        }

        public Users Authenticate(LoginModel model)
        {
            var user = users.SingleOrDefault(e => e.Email == model.Email && e.Password == model.Password);
            return user;
        }

        public Users SignUp(Users user)
        {
            users.Add(user);
            return user;
        }
    }
}






