using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Models;

namespace CashRegister.Common
{
    public class Util
    {


        /// <summary>
        /// To Get All the avaiable for coupons
        /// </summary>
        /// <returns> Returns List of DiscountCoupons </returns>
        public static List<DiscountCoupon> GetListOfCoupons()
        {
            return new List<DiscountCoupon>() {
                new DiscountCoupon{CouponID=1, ItemId=new List<int>() {1, 3}, CDetails=new CouponType{CType="QDiscount", CUnit="Nos", CMinVal=3, CDiscountVal=1}},
                new DiscountCoupon{CouponID=2, ItemId=new List<int>() {5}, CDetails=new CouponType{CType="PDiscount", CUnit="%", CMinVal=0, CDiscountVal=15}},
                new DiscountCoupon{CouponID=3, ItemId=new List<int>() {6}, CDetails=new CouponType{CType="PDiscount", CUnit="%", CMinVal=1, CDiscountVal=20}},
                new DiscountCoupon{CouponID=3, ItemId=new List<int>() {7}, CDetails=new CouponType{CType="PDiscount", CUnit="%", CMinVal=0, CDiscountVal=30}},
                new DiscountCoupon{CouponID=4, ItemId=new List<int>() {10}, CDetails=new CouponType{CType="QDiscount", CUnit="Nos", CMinVal=1, CDiscountVal=1}},
                new DiscountCoupon{CouponID=5, ItemId=new List<int>() {12}, CDetails=new CouponType{CType="QDiscount", CUnit="Nos", CMinVal=2, CDiscountVal=1}}
            };
        }

        /// <summary>
        ///  To Get All the available items
        /// </summary>
        /// <returns> Returns List of Item</returns>
        public static List<Item> GetListOfItems()
        {
            return new List<Item>()
            {
               new Item{Id = 1, Name = "Pen" , IType= new ItemType{Type="Count", Unit="Nos"}, Cost = 10},
               new Item{Id = 2, Name = "Pencil" , IType= new ItemType{Type="Count", Unit="Nos"}, Cost = 5},
               new Item{Id = 3, Name = "Book" , IType= new ItemType{Type="Count", Unit="Nos"}, Cost = 20},
               new Item{Id = 4, Name = "Apple" , IType= new ItemType{Type="Weight", Unit="Lbs"}, Cost = 10},
               new Item{Id = 5, Name = "Grapes" , IType= new ItemType{Type="Weight", Unit="Lbs"}, Cost = 50},
               new Item{Id = 6, Name = "Cherries" , IType= new ItemType{Type="Weight", Unit="Lbs"}, Cost = 10},
               new Item{Id = 7, Name = "Tomato" , IType= new ItemType{Type="Weight", Unit="Lbs"}, Cost = 10},
               new Item{Id = 8, Name = "Beetroot" , IType= new ItemType{Type="Weight", Unit="Lbs"}, Cost = 10},
               new Item{Id = 9, Name = "Carrot" , IType= new ItemType{Type="Weight", Unit="Lbs"}, Cost = 10},
               new Item{Id = 10, Name = "Coke-Cola" , IType= new ItemType{Type="Count", Unit="Nos"}, Cost = 10},
               new Item{Id = 11, Name = "Red Bull" , IType= new ItemType{Type="Count", Unit="Nos"}, Cost = 10},
               new Item{Id = 12, Name = "Pepsi" , IType= new ItemType{Type="Count", Unit="Nos"}, Cost = 10}
            };

        }


    }
}
