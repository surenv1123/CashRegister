using CashRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashRegister.Common;

namespace CashRegister.Repository
{

    /// <summary>
    /// This Interface provides shopping item operations
    /// </summary>
    public interface IItemRepository<T>
    {
       
        T Retrieve(int key);
    }

    /// <summary>
    /// This Class provides implementation for shopping item operations
    /// </summary>
    public class ItemRepository : IItemRepository<Item>
    {

        
        /// <summary>
        /// To Get all the shopping items
        /// </summary>
        /// <param name="Id"></param>
        /// <returns> Shopping Item </returns>
        public  Item Retrieve(int Id)
        {
            
            Item rItem =Util.GetListOfItems().Find(x => x.Id == Id);
            return rItem;
        }
    }
}