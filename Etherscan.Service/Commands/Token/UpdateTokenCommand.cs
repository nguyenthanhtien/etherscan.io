using MediatR;

namespace Etherscan.Service.Commands.Token
{
    public class UpdateTokenCommand : IRequest<bool>
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double TotalSupply { get; set; }
        public string ContractAddress { get; set; }
        public int TotalHolders { get; set; }
    }
}
