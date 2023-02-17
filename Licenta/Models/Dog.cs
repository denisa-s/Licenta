using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Dog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Breed { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string LifeStage { get; set; }
        public string SpecialNeeds { get; set; }
        public string MoralCharacteristics { get; set; }
        public int ID_food { get; set; }
        public int ID_room { get; set; }
        public int ID_employee { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
