﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string? message) : base(message)
        {
        }
    }
}
