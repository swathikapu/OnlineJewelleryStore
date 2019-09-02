using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineJewelleryStore.Models
{
    public class Cart
    {
        private List<CartItem> _Items = new List<CartItem>();
        public List<CartItem> Items {
            get { return _Items; }
            set { _Items = value; }
        }
        [DataType(DataType.Currency)]
        public decimal? TotalPrice
        {
            get
            {
                decimal? totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.TotalPrice;
                }
                return totalPrice;
            }
        }
        public int NumberOfItems
        {
            get
            {
                int numItems = 0;
                foreach (var item in Items)
                {
                    numItems += item.Quantity;
                }
                return numItems;
            }
        }
        public void AddItem(CartItem item)
        {
            int _index = getExistingItemIndex(item);
            if (_index == -1)
                _Items.Add(item);
            else
                _Items[_index].Quantity += 1;
        }

        public void RemoveItem(CartItem item)
        {
            int _index = getExistingItemIndex(item);
            if (_index != -1)
            {
                _Items[_index].Quantity -= 1;
                if (_Items[_index].Quantity == 0)
                    _Items.Remove(item);
            }
        }

        public void RemoveItem(int productId)
        {
            CartItem cartItem = null;
            foreach(var item in Items)
            {
                if(item.Product.Id == productId)
                {
                    cartItem = item;
                }
            }
            if(cartItem != null)
            {
                Items.Remove(cartItem);
            }
        }
        public int getExistingItemIndex(CartItem itemToCheck)
        {
            for(int i=0; i<_Items.Count(); i++)
            {
                CartItem item = _Items[i];
                if (item.Product.Id == itemToCheck.Product.Id)
                    return i;
            }
            return -1;
        }

        public CartItem GetItem(int productId)
        {
            CartItem cartItem = null;
            foreach(var item in Items)
            {
                if(item.Product.Id == productId)
                {
                    cartItem = item;
                }
            }
            return cartItem;
        }
    }
}