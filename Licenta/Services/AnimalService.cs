using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Licenta.Models;
namespace Licenta.Services
{
    public class AnimalService
    {
        static readonly HttpClient client = new HttpClient();
        public AnimalService()
        {
        }

        List<Animal> animalList;
        public async Task<List<Animal>> GetAnimals()
        {
            if (animalList?.Any() == true)
                return animalList;
            using HttpResponseMessage resp = await client.GetAsync("https://raw.githubusercontent.com/denisa-s/data/main/date.json");
            if (resp.IsSuccessStatusCode)
            {
                animalList = await resp.Content.ReadFromJsonAsync<List<Animal>>();
            }
            return animalList;
        }
    }
}
