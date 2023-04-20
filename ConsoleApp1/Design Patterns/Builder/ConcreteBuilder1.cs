using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.Builder {
    internal class ConcreteBuilder1 : IBuilder {
        private Product _product = new Product();
        public ConcreteBuilder1() { }
        public void Reset() => _product = new Product();
        public void BuildPartAVoid() => _product.AddPart("PartA1");
        public IBuilder BuildPartA() {
            _product.AddPart("PartA1");
            return this;
        }
        public void BuildPartBVoid() => _product.AddPart("PartB1");
        public IBuilder BuildPartB() {
            _product.AddPart("PartB1");
            return this;
        }
        public Product Build() {
            Product product = _product;
            Reset();
            return product;
        }
    }
}
