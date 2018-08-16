using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Models
{
    /// <summary>
    /// This Class Provides Discount Coupon information
    /// </summary>
    public class DiscountCoupon
    {
        public int CouponID { get; set; }
        public List<int> ItemId { get; set; }
        public CouponType CDetails { get; set; }
    }
}
