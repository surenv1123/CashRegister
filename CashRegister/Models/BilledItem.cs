using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Models
{
    /// <summary>
    /// This Model class contain all the properties of shopping item/cart
    /// </summary>
    public class BilledItem
    {
        public int SNo { get; set; }
        public string ItmName { get; set; }
        public double ItmQuantity { get; set; }
        public double ItmCost { get; set; }
        public string DisCntDetails { get; set; }
        public double TotCost { get; set; }
    }
}
