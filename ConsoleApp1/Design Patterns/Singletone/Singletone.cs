using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.Singletone {
    internal sealed class Singletone {
        private static Singletone _singletone;
        public static Singletone Instance {
            get {
                if (_singletone == null) {
                    _singletone = new Singletone();
                }
                return _singletone;
            }
        }
        private Singletone() { }
    }
}
