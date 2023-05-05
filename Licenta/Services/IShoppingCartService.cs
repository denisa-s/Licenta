using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Licenta.Models;
namespace Licenta.Services
{
    public interface IShoppingCartService
    {
        Task<IList<CartItem>> GetCartItemsAsync();
        Task AddItemToCartAsync(CartItem item);
        Task RemoveItemFromCartAsync(CartItem item);
        Task ClearCartAsync();
    }
}
