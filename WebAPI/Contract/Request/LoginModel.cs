using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Contract.Request
{
    public class LoginModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
