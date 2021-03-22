using System.Collections.Generic;
using System.Threading.Tasks;
using Etherscan.Service.Commands.Token;
using Etherscan.Service.Interface;
using Etherscan.Service.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Etherscan.Web.Controllers
{
    [ApiController]
    [Route("token")]
    public class TokenController : ControllerBase
    {
       
        private readonly ILogger<TokenController> _logger;
        private readonly ITokenService _tokenService;
        public TokenController(ILogger<TokenController> logger, ITokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IEnumerable<TokenViewModel>> GetAllToken()
        {
            return await _tokenService.GetTotalToken(new GetAllTokenCommand());
            
        }

        [HttpPut]
        [Route("updatetoken")]
        public async Task<bool> UpdateToken([FromBody]UpdateTokenCommand request)
        {
            return await _tokenService.UpdateToken(request);


        }

        [HttpGet]
        [Route("drawchart")]
        public async Task<ChartTokenViewModel> DrawPieChart()
        {
            return await _tokenService.DrawChartToken(new DrawChartCommand());

        }
    }
}
