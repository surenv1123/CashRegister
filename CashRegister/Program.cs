using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Models;
using CashRegister.Repository;
using CashRegister.Core;


namespace CashRegister
{
    /// <summary>
    ///  This Main Class Provides All the Cash Register features and implementation
    /// </summary>
    class Program
    {
        private static int MyItems = 1;
         //Dictonary for storing all the shopping cart item
        public static Dictionary<int, BilledItem> BilledItesmDict = new Dictionary<int,BilledItem> ();

        static void Main(string[] args)
        {
            for (int i = 0; i < MyItems; i++)
            {
                try
                {

                    if (MyItems == 1)
                    {
                        Console.WriteLine("Welcome to the Store....");
                        Console.Write("Please scan the item code (Enter item Id):");
                    }
                    else if (MyItems >= 1)
                    {
                        Console.Write("Please scan the next item code (Enter item Id):");
                    }

                    string inputItem = Console.ReadLine();
                    
                    if (Int32.TryParse(inputItem, out int num))// (foo, out int number1)) 
                    {
                        ItemRepository itemsRep = new ItemRepository();
                        Item finditem = itemsRep.Retrieve(num);
                        if (finditem == null)
                            Console.WriteLine("Input is not a valid item Id!");
                        else
                        {
                            Console.WriteLine("Item Name : " + finditem.Name + " --  Item Cost : " + finditem.Cost.ToString() + "$");
                            Console.Write("Enter the Quantity in " + finditem.IType.Unit + " : ");
                            string inputQuantity = Console.ReadLine();
                           
                            double Qnum = 0;
                            bool validInput = true;
                            // To check the item type and user input
                            if (finditem.IType.Type == "Count")
                            {
                                if (Int32.TryParse(inputQuantity, out int inum))
                                {
                                    validInput = true;
                                    Qnum = inum;
                                }
                                else
                                    validInput = false;
                            }
                            else
                            {
                                if (double.TryParse(inputQuantity, out Qnum))
                                    validInput = true;
                                else
                                    validInput = false;
                            }
                            if (validInput && Qnum > 0)
                            {
                                DiscountRepository desCop = new DiscountRepository();
                                DiscountCoupon findCop = desCop.Retrieve(num);
                                //  For no discount items
                                if (findCop == null || findCop.CouponID == 0)
                                {
                                    //Console.WriteLine("No Discount");
                                    // To calculate Total quantity by iterating through shopping cart if needed
                                    double totalQty = CashRegisterService.CalculateQty(Qnum, BilledItesmDict, finditem);
                                    // Adding item to shopping cart Dictionary
                                    CashRegisterService.CheckItemAndAdd(BilledItesmDict, CashRegisterService.CreateItem(finditem, totalQty, "-", totalQty * finditem.Cost), finditem);
                                   
                                    CashRegisterService.DisplayBill(BilledItesmDict);
                                }
                                else
                                {
                                    Console.WriteLine("Discount Value:" + findCop.CDetails.CDiscountVal.ToString());

                                    BilledItem billItem = new BilledItem
                                    {
                                        ItmName = finditem.Name,
                                        ItmQuantity = Qnum,
                                        ItmCost = finditem.Cost
                                    };

                                    if (finditem.IType.Type == "Count")
                                    {
                                        int FreeItems = 0;
                                        try
                                        {
                                            FreeItems = Convert.ToInt32(Qnum) / findCop.CDetails.CMinVal;
                                        }
                                        catch (Exception)
                                        {

                                            Console.WriteLine("Exception occurred while calculating free items");
                                        }
                                        if (FreeItems > 0)
                                        {
                                            // To Calculate Discount for Qunatity based items
                                            CashRegisterService.ApplyDiscount(BilledItesmDict, findCop, finditem, billItem, Qnum);
                                        }
                                        else
                                        {
                                            billItem.DisCntDetails = "-";
                                            billItem.TotCost = Qnum * finditem.Cost;
                                        }
                                    }
                                    else
                                    {
                                        if (Qnum >= findCop.CDetails.CMinVal)
                                        {
                                            // To Calculate Discount based on percentage 
                                            CashRegisterService.ApplyDiscountPct(BilledItesmDict, findCop,finditem, billItem, Qnum);
                                        }
                                        else
                                        {
                                            billItem.DisCntDetails = "-";
                                            billItem.TotCost = Qnum * finditem.Cost;
                                        }
                                    }
                                    // Adding item to shopping cart Dictionary
                                    CashRegisterService.CheckItemAndAdd(BilledItesmDict, billItem, finditem);
                                    CashRegisterService.DisplayBill(BilledItesmDict);
                                }
                            }
                            else
                                Console.WriteLine("Input is not a valid item Id!");

                        }
                    }
                    else
                        Console.WriteLine("Input is not a valid item Id!");
                    ContinuePurchase();
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\n\n\n\n\n{0}\n\n\n\n", e.Message);
                    ContinuePurchase();
                }
            }
        }

     

        /// <summary>
        ///  To Check whether User wants continue Purchase
        /// </summary>
        private static void ContinuePurchase()
        {
            Console.Write("Continue Shopping?    ( Any Key / N to Final Bill )  ");
            string tryReadKey = Console.ReadLine().ToUpper();
            if (tryReadKey != "N")
                MyItems += 1;
            else
            {
                Console.WriteLine("***********************************************************************");
                Console.WriteLine("                             Final Bill                                ");
                CashRegisterService.DisplayBill(BilledItesmDict);
                Console.WriteLine("::::::::::::::::::::::::Thank You Visit Again::::::::::::::::::::::::::");
                Console.ReadLine();
            }
        }

    }
}
