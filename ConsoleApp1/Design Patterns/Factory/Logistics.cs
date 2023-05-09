﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.Factory {
    abstract class Logistics {
        public abstract ITransport CreateTransport();
    }
}