﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    public interface IItems
    {
        string Name { get; }
        string Type { get; }

        void ShowItems();
    }
}
