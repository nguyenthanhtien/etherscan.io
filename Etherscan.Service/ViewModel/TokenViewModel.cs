using System;
using System.Collections.Generic;
using System.Text;

namespace Etherscan.Service.ViewModel
{
    public class TokenViewModel
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double TotalSupply { get; set; }
        public string ContractAddress { get; set; }
        public int TotalHolders { get; set; }
    }
}
