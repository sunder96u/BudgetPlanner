using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPlanner.ViewModels
{
    public class BudgetItemsMorrisChart
    {
        public List<MorrisChartData> Data { get; set; }

        public BudgetItemsMorrisChart()
        {
            this.Data = new List<MorrisChartData>();
        }
    }

    public class MorrisChartData
    {
        public string BudgetItem { get; set; }
        public string CurrentBalance { get; set; }
        public string TargetBalance { get; set; }
    }
}