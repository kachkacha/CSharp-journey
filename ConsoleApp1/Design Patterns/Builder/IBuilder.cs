using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.Builder {
    internal interface IBuilder {
        IBuilder BuildPartA();
        IBuilder BuildPartB();

    }
}
