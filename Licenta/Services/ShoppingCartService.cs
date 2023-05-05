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
            // In a real-world scenario, you would retrieve the cart items from a database or web service.
            // For the sake of simplicity, we return a copy of the internal list of cart items.
            return await Task.FromResult(_cartItems.ToList());
        }

        public async Task AddItemToCartAsync(CartItem item)
        {
            // Check if the item already exists in the cart
            var existingItem = _cartItems.FirstOrDefault(i => i.Name == item.Name);
            if (existingItem != null)
            {
                // If the item already exists, increase its quantity instead of adding a new item
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                // If the item doesn't exist, add it to the cart
                _cartItems.Add(item);
            }

            // In a real-world scenario, you would save the changes to the database or web service.
            // For the sake of simplicity, we don't do that in this example.
            await Task.CompletedTask;
        }

        public async Task RemoveItemFromCartAsync(CartItem item)
        {
            // Remove the item from the cart
            _cartItems.Remove(item);

            // In a real-world scenario, you would save the changes to the database or web service.
            // For the sake of simplicity, we don't do that in this example.
            await Task.CompletedTask;
        }

        public async Task ClearCartAsync()
        {
            // Remove all items from the cart
            _cartItems.Clear();

            // In a real-world scenario, you would save the changes to the database or web service.
            // For the sake of simplicity, we don't do that in this example.
            await Task.CompletedTask;
        }
    }
}
