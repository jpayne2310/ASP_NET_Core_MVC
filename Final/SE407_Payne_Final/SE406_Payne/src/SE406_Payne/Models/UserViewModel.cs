using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SE406_Payne.Models
{
    public class UserViewModel
    {
        public List<User> UserList { get; set; }
        public User NewUser { get; set; }
    }
}
