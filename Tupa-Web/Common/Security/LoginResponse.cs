﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Common.Security
{
    public class LoginResponse
    {
        public string uid { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public DateTime expiration { get; set; }
    }
}