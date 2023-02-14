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
        public string breed { get; set; }
        public string size { get; set; }
        public string name { get; set; }
        public string life_stage { get; set; }
        public string special_needs { get; set; }
        public string moral_characteristics { get; set; }
        public int ID_food { get; set; }
        public int ID_room { get; set; }
        public int CNP_employee { get; set; }
        public DateTime registration_date { get; set; }
    }
}
