﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Share.Responses
{
    internal class ActionResponse<T>
    {
        public bool WasSuccessful { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}