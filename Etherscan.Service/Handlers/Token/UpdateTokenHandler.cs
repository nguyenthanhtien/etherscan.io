using System;
using System.Threading;
using System.Threading.Tasks;
using Etherscan.Data;
using Etherscan.Service.Commands.Token;
using MediatR;

namespace Etherscan.Service.Handlers.Token
{
    public class UpdateTokenHandler : IRequestHandler<UpdateTokenCommand, bool>
    {
        private readonly EtherscanDbContext _dbContext;
        public UpdateTokenHandler(EtherscanDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<bool> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
                throw new ArgumentException("Request Update Token can not be null!");
            var tokenUpdate = new Entity.Token()
            {
                Contract_Address = request.ContractAddress,
                Name = request.Name,
                Symbol = request.Symbol,
                Total_Holders = request.TotalHolders,
                Total_Supply = request.TotalSupply
            };
            _dbContext.Token.Update(tokenUpdate);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
