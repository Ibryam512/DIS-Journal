﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Journal.Models
{
    class Teacher : User
    {
        public Teacher(string firstName, string lastName, string email, string password, DateTime birth) : base(firstName, lastName, email, password, birth, "teacher")
        { }
    }
}