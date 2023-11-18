using domain.DTO;
using Domain.DTO;
using infrastructure.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly LikeServices _likeServices;
        public LikeController(LikeServices likeServices)
        {
            _likeServices = likeServices;
        }

        [HttpPost]
        public ActionResult<ResultDTO> AddLike(LikeDTO likeDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(_likeServices.AddLikeIfNotExistOrDeleted(likeDTO));
        }
    }
}
