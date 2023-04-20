using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.AbstractFactory {
    internal class ConcreteFactory2 : AbstractFactory {
        public override IProductA CreateProductA() => new ConcreteProductA2();

        public override IProductB CreateProductB() => new ConcreteProductB2();
    }
}
