using System;

namespace Etherscan.Entity
{
    public class Token
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Total_Supply { get; set; }
        public string Contract_Address { get; set; }
        public int Total_Holders { get; set; }

    }
}
