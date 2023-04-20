using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Design_Patterns.Singletone {
    internal sealed class UltimateSingletone {
        private static Lazy<UltimateSingletone> _singletone = new Lazy<UltimateSingletone>(() => new UltimateSingletone());
        public static UltimateSingletone Instance { get { return _singletone.Value; } }
        private UltimateSingletone() { }
    }
}
