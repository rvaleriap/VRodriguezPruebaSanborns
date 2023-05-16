﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Result
    {
        public bool Correct { get; set; }
        public string Message { get; set; }
        public object Object { get; set; }
        public Exception ex { get; set; }
        public List<object> Objects { get; set; }
    }
}
