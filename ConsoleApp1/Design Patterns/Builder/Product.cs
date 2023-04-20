using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.Builder {
    internal class Product {
        private List<object> _parts = new List<object>();
        public void AddPart(object part) => _parts.Add(part);
    }
}
