using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApp.Models
{
    public class OrderDetail
    {
      
            public int OrderDetailId { get; set; }
            public int OrderId { get; set; }
            public int RecipeId { get; set; }
            public int Amount { get; set; }
            public decimal Price { get; set; }
            public Recipe Recipe { get; set; }
            public Order Order { get; set; }
        
    }
}
