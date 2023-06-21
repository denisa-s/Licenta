using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Models;
namespace Licenta.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IList<CartItem> _cartItems;

        public ShoppingCartService()
        {
            _cartItems = new List<CartItem>();
        }

        public async Task<IList<CartItem>> GetCartItemsAsync()
        {
            return await Task.FromResult(_cartItems.ToList());
        }

        public async Task AddItemToCartAsync(CartItem item)
        {
            var existingItem = _cartItems.FirstOrDefault(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                _cartItems.Add(item);
            }
            await Task.CompletedTask;
        }

        public async Task RemoveItemFromCartAsync(CartItem item)
        {
            _cartItems.Remove(item);
            await Task.CompletedTask;
        }

        public async Task ClearCartAsync()
        {
            _cartItems.Clear();
            await Task.CompletedTask;
        }
    }
}
