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
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string MeasureUnits { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public int ID_provider { get; set; }
    }
}
