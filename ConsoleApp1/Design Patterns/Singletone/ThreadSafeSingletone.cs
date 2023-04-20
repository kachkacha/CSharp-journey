using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.Singletone {
    internal sealed class ThreadSafeSingletone {
        private static ThreadSafeSingletone _singletone;
        private static readonly object _lock = new object();
        public static ThreadSafeSingletone Instance {
            get {
                if (_singletone == null) {
                    lock (_lock) {
                        if (_singletone == null) {
                            _singletone = new ThreadSafeSingletone();
                        }
                    }
                }
                return _singletone;
            }
        }
        private ThreadSafeSingletone() { }
    }
}
