﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Models.Security
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}