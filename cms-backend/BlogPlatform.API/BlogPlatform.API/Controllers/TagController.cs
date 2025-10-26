using BlogPlatform.API.Data;
using BlogPlatform.API.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogPlatform.API.Controllers
{
    // The [Route] attribute tells ASP.NET Core that this controller responds to API requests. 
    // "[controller]" is a placeholder for the controller name, so the route is /api/Tag
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        // 1. Dependency: This private field holds the reference to the IRepository, 
        // specialized for the Tag entity.
        private readonly IRepository<Tag> _repository;

        // 2. Dependency Injection (DI) is used here: The system automatically provides 
        // an instance of the concrete SqlRepository<Tag> class.
        public TagController(IRepository<Tag> repository)
        {
            _repository = repository;
        }

        // 3. Endpoint: Handles HTTP GET requests to the /api/Tag route.
        [HttpGet]
        public async Task<ActionResult> GetAllTags()
        {
            // Use the generic repository to execute the database query 
            // (SELECT * FROM Tags) asynchronously.
            var tagList = await _repository.GetAll();

            // Return the list of tags as JSON with a 200 OK status.
            return Ok(tagList);
        }
    }
}
