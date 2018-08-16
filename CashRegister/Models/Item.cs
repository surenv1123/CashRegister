using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Models
{
    /// <summary>
    /// This Class Provides Shopping item
    /// </summary>
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType IType { get; set; }
        public double Cost { get; set; }
    }
}
