﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models.ProductViewModels
{
    public class ProductSearchViewModel
    {
        public string Search { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
