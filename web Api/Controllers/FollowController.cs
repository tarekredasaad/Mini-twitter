using domain.DTO;
using Domain.DTO;
using infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly FollowServices _followServices;
        public FollowController(FollowServices followServices) 
        {
            _followServices = followServices;
        }

        [HttpPost]
        public ActionResult<ResultDTO> FollowIfExistOrUnfollow(FollowDTO followDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_followServices.FollowIfExistOrUnfollow(followDTO));
        }
    }
}
