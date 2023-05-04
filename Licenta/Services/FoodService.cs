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
        HttpClient httpClient;
        public FoodService()
        {
            this.httpClient = new HttpClient();
        }

        List<Food> foodList;
        public async Task<List<Food>> GetFoods()
        {
            if (foodList?.Count > 0)
                return foodList;

            var response = await httpClient.GetAsync("https://raw.githubusercontent.com/denisa-s/food/main/food.json");
            if (response.IsSuccessStatusCode)
            {
                foodList = await response.Content.ReadFromJsonAsync<List<Food>>();
            }

            return foodList;
        }
    }
}
