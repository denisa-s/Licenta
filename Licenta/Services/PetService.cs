using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Licenta.Models;
namespace Licenta.Services
{
    public class PetService
    {
        HttpClient httpClient;
        public PetService()
        {
            this.httpClient = new HttpClient();
        }

        List<Pet> petList;
        public async Task<List<Pet>> GetPets()
        {
            if (petList?.Count > 0)
                return petList;

            var response = await httpClient.GetAsync("https://raw.githubusercontent.com/denisa-s/data/main/date.json");
            if (response.IsSuccessStatusCode)
            {
                petList = await response.Content.ReadFromJsonAsync<List<Pet>>();
            }

            return petList;
        }

    }
}
