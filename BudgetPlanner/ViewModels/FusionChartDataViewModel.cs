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
        public string label { get; set; }
        public string value { get; set; }
    }
}