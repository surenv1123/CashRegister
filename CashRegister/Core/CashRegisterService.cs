using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Models;

namespace CashRegister.Core
{
    /// <summary>
    /// This Class provides implementation for Core Business Logic methods
    /// </summary>
    public class CashRegisterService
    {
       

        /// <summary>
        /// To Apply Discount on Quantity
        /// </summary>
        /// <param name="BilledItems"></param>
        /// <param name="findCop"></param>
        /// <param name="findItem"></param>
        /// <param name="billedItem"></param>
        /// <param name="Qnum"></param>
        /// <remarks> This Methods First calculates total quantity by iterating through items if needed. Calculate Discount Quantity by adding Discount coupon details.
        ///  Total Discount Quantity will be calculated by dividing total quantity and Discount Quantity. Total cost will be calculated after removing discount quantity
        /// </remarks>
        public static void ApplyDiscount(Dictionary<int, BilledItem> BilledItems, DiscountCoupon findCop, Item findItem, BilledItem billedItem, double Qnum)
        {
           
            BilledItems.TryGetValue(findItem.Id, out BilledItem DictValue);
            double totalQty = Qnum;
            if (DictValue != null)
            { 
               totalQty = DictValue.ItmQuantity + Qnum;
            }
            int totalQtyWithDiscout = findCop.CDetails.CDiscountVal + findCop.CDetails.CMinVal;
            double totalDiscountQty = (int)totalQty / totalQtyWithDiscout;
            billedItem.DisCntDetails ="Buy " + findCop.CDetails.CMinVal.ToString() +" Get "+ findCop.CDetails.CDiscountVal.ToString()+" Free";
            billedItem.TotCost = (totalQty - totalDiscountQty) * findItem.Cost;
            billedItem.ItmQuantity = totalQty;

        }
         
        /// <summary>
        /// To Apply Discout Percentage for items in the cart based on item discount value specified
        /// </summary>
        /// <param name="BilledItems"></param>
        /// <param name="findCop"></param>
        /// <param name="findItem"></param>
        /// <param name="billedItem"></param>
        /// <param name="Qnum"></param>
        /// <remarks> This Method First calculates total item quantity  by iterating through items. Discount amt calculated based on discount % information available for item
        /// </remarks>
        public static void ApplyDiscountPct(Dictionary<int, BilledItem> BilledItems , DiscountCoupon findCop, Item findItem, BilledItem billedItem,double Qnum)
        {
           
            BilledItems.TryGetValue(findItem.Id, out BilledItem DictValue);
            double totalQty = Qnum;
            if (DictValue != null)
            {
              totalQty = DictValue.ItmQuantity + Qnum;
            }
            billedItem.DisCntDetails = findCop.CDetails.CDiscountVal.ToString() + findCop.CDetails.CUnit;
            billedItem.TotCost = totalQty * findItem.Cost * (double)(100 - findCop.CDetails.CDiscountVal) / 100;
            billedItem.ItmQuantity = totalQty;
        }



        /// <summary>
        ///  To Display All items in shoping cart
        /// </summary>
        /// <param name="BilledItems"></param>
        public static void DisplayBill(Dictionary<int,BilledItem> BilledItems)
        {
            double gTotal = 0;
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("SNo | Item Name | Quantity | Unit Cost | Discount Details | Total Cost");
            Console.WriteLine("-----------------------------------------------------------------------");
            // foreach (BilledItem bItm in BilledItems)
            int count = 1;
            foreach (KeyValuePair<int, BilledItem> item in BilledItems)
                {
                BilledItem bItm = item.Value;
                Console.WriteLine(String.Format("{0,3} | {1,-9} | {2,8} | {3,9} | {4,-16} | {5,10}", count++, bItm.ItmName, bItm.ItmQuantity, bItm.ItmCost, bItm.DisCntDetails, bItm.TotCost.ToString() + "$"));
                gTotal = gTotal + bItm.TotCost;
            }
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,57} | {1,10}", "Grand Total ", gTotal.ToString() + "$"));
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("");
        }


        /// <summary>
        ///  This Methods Add/update item to shopping cart 
        /// </summary>
        /// <param name="BilledItems"></param>
        /// <param name="billedItem"></param>
        /// <param name="findItem"></param>
        public static void CheckItemAndAdd(Dictionary<int, BilledItem> BilledItems, BilledItem billedItem,Item findItem)
        {
            if (BilledItems.ContainsKey(findItem.Id))
            {
                BilledItems[findItem.Id] = billedItem;


            } else
            {
                BilledItems.Add(findItem.Id, billedItem);
            }

        }


        /// <summary>
        ///  To Create Shopping Cart item
        /// </summary>
        /// <param name="findItem"></param>
        /// <param name="Qnum"></param>
        /// <param name="discDtl"></param>
        /// <param name="totalCost"></param>
        /// <returns></returns>
        public static BilledItem CreateItem(Item findItem, double Qnum,String discDtl,double totalCost)
        {
            BilledItem billItem = new BilledItem
            {
               
                ItmName = findItem.Name,
                ItmQuantity = Qnum,
                ItmCost = findItem.Cost,
                DisCntDetails = discDtl,
                TotCost = totalCost
            };
            return billItem;

        }

        /// <summary>
        ///  To Calculate Item Quantity 
        /// </summary>
        /// <param name="Qnum"></param>
        /// <param name="BilledItems"></param>
        /// <param name="findItem"></param>
        /// <returns></returns>
        public static double CalculateQty(double Qnum, Dictionary<int, BilledItem> BilledItems,Item findItem)
        {
            double TotalQty = Qnum;
           
            BilledItems.TryGetValue(findItem.Id, out BilledItem  BItem);
            if(BItem != null)
            {
                TotalQty = BItem.ItmQuantity + Qnum;
            }
            return TotalQty;
        }



    }
}
