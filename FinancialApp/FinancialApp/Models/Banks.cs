using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Models
{
    class Banks
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public Banks()
        {
            Name = "";
            Address = "";
            City = "";
            State = "";
            Zip = "";
            Phone = "";
        }
    }
}
