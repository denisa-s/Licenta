using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string measure_units { get; set; }
        public decimal price { get; set; }
        public string details { get; set; }
        public int ID_provider { get; set; }
    }
}
