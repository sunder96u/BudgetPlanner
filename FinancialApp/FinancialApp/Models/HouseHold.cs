using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Models
{
    class HouseHold
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public HouseHold()
        {
            Id = "";
            Name = "";
            Description = ""; 
        }
    }
}
