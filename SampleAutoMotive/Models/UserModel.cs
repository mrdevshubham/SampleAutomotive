using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAutoMotive.Models
{
    public class UserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool isRememberMe { get; set; }
    }
}