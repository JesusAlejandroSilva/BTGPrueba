using BTGFunds.Application.DTOs;
using BTGFunds.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BTGFunds.API.Controllers
{
    [ApiController]
    [Route("api/funds")]
    public class FundsController : ControllerBase
    {
        private readonly FundService _fundService;

        public FundsController(FundService fundService)
        {
            _fundService = fundService;
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] SubscribeRequest request)
        {
            await _fundService.Subscribe(request.UserId, request.FundId);
            return Ok("Suscripción realizada");
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> Cancel([FromBody] CancelRequest request)
        {
            await _fundService.Cancel(request.SubscriptionId);
            return Ok("Suscripción cancelada");
        }

        [HttpGet("transactions/{userId}")]
        public async Task<IActionResult> Transactions(string userId)
        {
            var result = await _fundService.GetTransactions(userId);
            return Ok(result);
        }
    }
}
