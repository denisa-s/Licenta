using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Licenta.Models;

namespace Licenta.Services
{
    public class FoodService    
    {
        static readonly HttpClient client = new HttpClient();
        public FoodService()
        {
            
        }
        List<Food> foodList;
        public async Task<List<Food>> GetFoods()
        {
            if (foodList?.Any() == true)
                return foodList;
            using HttpResponseMessage resp = await client.GetAsync("https://raw.githubusercontent.com/denisa-s/food/main/food.json");
            if (resp.IsSuccessStatusCode)
            {
                foodList = await resp.Content.ReadFromJsonAsync<List<Food>>();
            }
            return foodList;
        }
    }
}
