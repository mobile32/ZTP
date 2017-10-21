using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.BLL.DTO
{
    public class PizzaDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
