﻿using owinserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace owinserver.Service
{
    public class UserService
    {

        public User GetUserByCredentials(string email, string password)
        {
            if (email != "email@domain.com" && password != "password")
            {
                return null;
            }
            User user = new User()
            {
                Id = "1",
                Name = "World",
                Email = email,
                Password = password
            };
            return user;

        }

    }
}