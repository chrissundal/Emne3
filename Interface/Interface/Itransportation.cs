using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface Itransportation
    {
        public string Brand { get; set; }
        public string RegistrationNumber { get; set; }
        Color Color { get; set; }

        public void Show();
    }
}
