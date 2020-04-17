using System;
using System.Collections.Generic;
using System.Text;

namespace CovidTP.DAL.EntityModels
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
