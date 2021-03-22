using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Etherscan.Entity;
using Etherscan.Service.Commands.Token;
using Etherscan.Service.ViewModel;

namespace Etherscan.Service.Interface
{
    public interface ITokenService
    {
        Task<IEnumerable<TokenViewModel>> GetTotalToken(GetAllTokenCommand command);
        Task<bool> UpdateToken(UpdateTokenCommand command);
        Task<ChartTokenViewModel> DrawChartToken(DrawChartCommand command);

    }
}
