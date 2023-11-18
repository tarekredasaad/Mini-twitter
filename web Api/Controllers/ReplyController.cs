using domain.DTO;
using Domain.DTO;
using infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly ReplyServices replyServices;

        public ReplyController(ReplyServices replyServices)
        {
            this.replyServices = replyServices;
        }

        [HttpPost]
        public ActionResult<ResultDTO> AddReply(ReplyDTO replyDTo)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(replyServices.AddReply(replyDTo));
        }
    }
}
