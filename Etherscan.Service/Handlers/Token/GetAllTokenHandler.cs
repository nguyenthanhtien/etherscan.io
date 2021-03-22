using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Etherscan.Data;
using Etherscan.Service.Commands.Token;
using Etherscan.Service.ViewModel;
using MediatR;

namespace Etherscan.Service.Handlers.Token
{
    public class GetAllTokenHandler: IRequestHandler<GetAllTokenCommand, IEnumerable<TokenViewModel>>
    {
        private readonly EtherscanDbContext _dbContext;
        public GetAllTokenHandler(EtherscanDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<TokenViewModel>> Handle(GetAllTokenCommand request, CancellationToken cancellationToken)
        {
            return _dbContext.Token.Select(x => new TokenViewModel
            {
                ContractAddress = x.Contract_Address,
                Id = x.Id,
                Name =  x.Name,
                Symbol = x.Symbol,
                TotalHolders =  x.Total_Holders,
                TotalSupply = x.Total_Supply
            }).ToList();
        }
    }
}
