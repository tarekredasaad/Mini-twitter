using Domain.DTO;
using Domain.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    //[EnableCors(origins: "https://localhost:4200/", headers: "*", methods: "*")]

    public class PostController : ControllerBase
    {
        private readonly PostServices postServices;
        public PostController(PostServices postServices)
        {
            this.postServices = postServices;
        }

        [HttpPost]
        public ActionResult<ResultDTO> AddPost(CreatePostDTO postDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(postServices.AddPost(postDTO));
        }
        [HttpPost("retweet")]
        public ActionResult<ResultDTO> Retweet(int id,CreatePostDTO postDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(postServices.Retweet(id,postDTO));
        }
        [HttpGet]
        public ActionResult<ResultDTO> GetFollersPosts(string id, int take = 5, int skip = 5)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(postServices.GetFollersPosts(id,take,skip));
        }


         [HttpPut]
        public ActionResult<ResultDTO> EditProduct(int id,CreatePostDTO postDTO)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(postServices.EditPost(id,postDTO));
        }
        [HttpDelete]
        public ActionResult<ResultDTO> RemoveProduct(int id)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultDTO() { StatusCode = 400, Data = ModelState }); };
            return Ok(postServices.DeletePost(id));
        }
    }
}
