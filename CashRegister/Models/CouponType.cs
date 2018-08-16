using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Models
{
    /// <summary>
    /// This Class Provides Discount Coupon Details
    /// </summary>
    public class CouponType
    {
        public string CType { get; set; }
        public string CUnit { get; set; }
        public int CMinVal { get; set; }
        public int CDiscountVal { get; set; }
    }
}
