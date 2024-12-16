using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netthandel
{
    internal interface IProducts
    {
        string Name { get; }
        string Category { get; }
        int Stock { get; }
        int Price { get; }
        string Measurement { get; }
        void ShowInfo();

        void RemoveFromStock(int amount);
        void SetStock(int amount);
        IProducts Clone(int stock);
    }
}
