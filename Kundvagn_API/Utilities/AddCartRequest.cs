﻿using Kundvagn_API.Models;

namespace Kundvagn_API.Utilities
{
    public class AddCartRequest
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public List<CartItem>? Items { get; set; }
    }
}