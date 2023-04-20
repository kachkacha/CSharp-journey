using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.AbstractFactory {
    internal abstract class AbstractFactory {
        public abstract IProductA CreateProductA();
        public abstract IProductB CreateProductB();
    }
}
