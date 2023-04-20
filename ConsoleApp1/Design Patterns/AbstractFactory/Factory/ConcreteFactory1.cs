using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.AbstractFactory {
    internal class ConcreteFactory1 : AbstractFactory {
        public override IProductA CreateProductA() => new ConcreteProductA1();

        public override IProductB CreateProductB() => new ConcreteProductB1();
    }
}
