﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum Role
    {
        None = 0,
        Member = 1,
        Admin = 3,
        Teacher = 5
    }
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int BirthDate { get; set; }
        public string Email { get; set; }

    
    }
}
