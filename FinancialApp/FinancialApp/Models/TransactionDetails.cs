﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Models
{
    class TransactionDetails
    {
        public string Amount { get; set; }
        public string Memo { get; set; }
        public string Created { get; set; }
        public string Type { get; set; }

        public TransactionDetails()
        {
            Amount = "";
            Memo = "";
            Created = "";
            Type = "";
        }
    }
}
