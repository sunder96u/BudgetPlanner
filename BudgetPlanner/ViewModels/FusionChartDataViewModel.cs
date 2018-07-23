using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPlanner.ViewModels
{
    public class FusionChartDataViewModel
    {
            public List<FusionChartData> Data { get; set; }

            public FusionChartDataViewModel()
            {
                this.Data = new List<FusionChartData>();
            }

    }

    public class FusionChartData
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
}