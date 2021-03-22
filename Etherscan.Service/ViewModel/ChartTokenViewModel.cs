using System.Collections.Generic;

namespace Etherscan.Service.ViewModel
{
    public class ChartTokenViewModel
    {
        public IEnumerable<string> ChartLabels { get; set; }
        public IEnumerable<double> ChartData { get; set; }
    }
}
