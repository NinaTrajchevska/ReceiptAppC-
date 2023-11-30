﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptApp
{
    public class Product
    {
        public string Name { get; set; }
        public bool Domestic { get; set; }
        public decimal Price { get; set; }
        public int? Weight { get; set; }
        public string Description { get; set; }
    }

}
