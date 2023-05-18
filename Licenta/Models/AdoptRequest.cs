﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class AdoptRequest
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string AddressDetails { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CNP { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Date { get; set; }
    }
}
