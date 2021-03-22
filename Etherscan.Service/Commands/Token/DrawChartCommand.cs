using Etherscan.Service.ViewModel;
using MediatR;

namespace Etherscan.Service.Commands.Token
{
    public class DrawChartCommand : IRequest<ChartTokenViewModel>
    {
    }
}
