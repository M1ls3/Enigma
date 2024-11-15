using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    public class Computer
    {
        public string characteristic1 { get; set; }
        public string characteristic2 { get; set; }
        public string characteristic3 { get; set; }

        public Computer()
        {
            characteristic1 = null;
            characteristic2 = null;
            characteristic3 = null;
        }

        public Computer(string characteristic1, string characteristic2, string characteristic3)
        {
            this.characteristic1 = characteristic1;
            this.characteristic2 = characteristic2;
            this.characteristic3 = characteristic3;
        }
    }
}
