using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Contract.Request;
using WebAPI.Models;

namespace WebAPI.Respository
{
   public interface IUsers
    {
        Users Authenticate(LoginModel model);
        Users SignUp(Users users);
        
    }
}
