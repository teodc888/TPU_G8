﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Model.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
