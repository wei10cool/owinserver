﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace owinserver.Models
{
    public class TokenStore
    {
        public string token { get; set; }
        public string UserId { get; set; }
    }
}