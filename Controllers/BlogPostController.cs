namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Services;
using WebApi.data;
using Microsoft.EntityFrameworkCore;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BlogPostController : ControllerBase
{
   // private IUserService _userService;
    private readonly ADBContext _dbContext;

    public BlogPostController(IUserService userService, ADBContext dbContext)
    {
       // _userService = userService;
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogPost>>> GetBooks()
    {
        return await _dbContext.BlogPosts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        if (id < 1)
            return BadRequest();
        var blogPosts = await _dbContext.BlogPosts.FirstOrDefaultAsync(m => m.Id == id);
        if (blogPosts == null)
            return NotFound();
        return Ok(blogPosts);

    }

    [HttpPost]
    public async Task<IActionResult> Post(BlogPost blogPost)
    {
        _dbContext.Add(blogPost);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(BlogPostData blogPostData)
    {
        if (blogPostData == null || blogPostData.Id == 0)
            return BadRequest();

        var blogPost = await _dbContext.BlogPosts.FindAsync(blogPostData.Id);
        if (blogPost == null)
            return NotFound();
        blogPost.Title = blogPostData.Title;
        blogPost.Content = blogPostData.Content;
        blogPost.CreatedAt = blogPostData.CreatedAt;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id < 1)
            return BadRequest();
        var blogPost = await _dbContext.BlogPosts.FindAsync(id);
        if (blogPost == null)
            return NotFound();
        _dbContext.BlogPosts.Remove(blogPost);
        await _dbContext.SaveChangesAsync();
        return Ok();

    }
}

