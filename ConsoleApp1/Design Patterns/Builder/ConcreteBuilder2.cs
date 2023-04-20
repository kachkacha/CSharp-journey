using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.Builder {
    internal class ConcreteBuilder2 : IBuilder {
        private Product _product = new Product();
        public ConcreteBuilder2() { }
        public void Reset() => _product = new Product();
        public void BuildPartAVoid() => _product.AddPart("PartA2");
        public IBuilder BuildPartA() {
            _product.AddPart("PartA2");
            return this;
        }
        public void BuildPartBVoid() => _product.AddPart("PartB2");
        public IBuilder BuildPartB() {
            _product.AddPart("PartB2");
            return this;
        }
        public Product Build() {
            Product product = _product;
            Reset();
            return product;
        }
    }
}
