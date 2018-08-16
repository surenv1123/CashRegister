using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Models;
using CashRegister.Common;


namespace CashRegister.Repository
{
    /// <summary>
    /// This interface provides methods for discount coupon operations
    /// </summary>
    public interface IDiscountRepository<T>
    {
        T Retrieve(int key);
    }

    /// <summary>
    /// This Class provides implementation for discount coupon operations
    /// </summary>
    public class DiscountRepository : IDiscountRepository<DiscountCoupon>
    {
        

       /// <summary>
       /// This method retrives Discount coupon information for shopping item
       /// </summary>
       /// <param name="Id"></param>
       /// <returns> Discount Detail </returns>
       public  DiscountCoupon Retrieve(int Id)
        {
            var fItem = Util.GetListOfCoupons().Where(dc => dc.ItemId.Any(p => p == Id));

            if (fItem != null)
            {
                List<DiscountCoupon> rItem = fItem.ToList();
                if (rItem.Count > 0)
                    return rItem[0];
            }

            DiscountCoupon rItem1 = new DiscountCoupon();
            return rItem1;
        }
    }
}
