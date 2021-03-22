using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Etherscan.Data;
using Etherscan.Service.Commands.Token;
using Etherscan.Service.ViewModel;
using MediatR;

namespace Etherscan.Service.Handlers.Token
{
    public class DrawChartHandler : IRequestHandler<DrawChartCommand, ChartTokenViewModel>
    {
        private readonly EtherscanDbContext _dbContext;
        public DrawChartHandler(EtherscanDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<ChartTokenViewModel> Handle(DrawChartCommand request, CancellationToken cancellationToken)
        {

            var data = _dbContext.Token.ToList();

            return new ChartTokenViewModel
            {
                ChartData = data.Select(x => x.Total_Supply),
                ChartLabels = data.Select(x => x.Name)
            };

        }
    }
}
