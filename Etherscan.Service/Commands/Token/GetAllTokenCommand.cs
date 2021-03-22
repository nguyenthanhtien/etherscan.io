using System;
using System.Collections.Generic;
using System.Text;
using Etherscan.Service.ViewModel;
using MediatR;

namespace Etherscan.Service.Commands.Token
{
    public class GetAllTokenCommand : IRequest<IEnumerable<TokenViewModel>>
    {
    }
}
