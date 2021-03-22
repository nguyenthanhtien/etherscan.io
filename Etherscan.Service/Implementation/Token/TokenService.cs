using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etherscan.Data;
using Etherscan.Entity;
using Etherscan.Service.Commands.Token;
using Etherscan.Service.Interface;
using Etherscan.Service.ViewModel;
using MediatR;

namespace Etherscan.Service
{
    public class TokenService : ITokenService
    {
        private readonly IMediator _mediator;

        public TokenService(IMediator mediator)
        {
            this._mediator = mediator;
        }


        public async Task<IEnumerable<TokenViewModel>> GetTotalToken(GetAllTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<bool> UpdateToken(UpdateTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ChartTokenViewModel> DrawChartToken(DrawChartCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
