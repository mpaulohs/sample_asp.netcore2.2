using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demo.Domain.Models;
using demo.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using demo.UI.Site.Repository;

namespace demo.UI.Site.ControllersApi
{
    public class Blog2
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly DemoContext _context;
        private readonly IExportXLS _blogRepository;
        private IConfiguration _config;

        public BlogsController(DemoContext context, IConfiguration config, IExportXLS blogRepository)
        {
            _context = context;
            _config = config;
            _blogRepository = blogRepository;

        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<IEnumerable<Blog2>> GetBlogs()
        {
           // return await _context.Blogs.ToListAsync();

            using (OracleConnection conexao = new OracleConnection(
                _config.GetConnectionString("BaseIndicadores")))
            {
                var result = await conexao.QueryAsync<Blog2>(
                    "SELECT b.Id, b.description FROM BLOG B " +
                    "ORDER BY b.description");

                return result;
            }
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog2>> GetBlog(int id)
        {

            using (OracleConnection conexao = new OracleConnection(
                _config.GetConnectionString("BaseIndicadores")))
            {
                var query = string.Format(@"select b.Id, b.description FROM blog b where b.Id = {0}", id);
                var result =  await conexao.QueryFirstOrDefaultAsync<Blog2>(query);

                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            //// var blog = await _context.Blogs.FindAsync(id);
            //var blog = await _blogRepository.GetBlogByID(id);

            //if (blog == null)
            //{
            //    return NotFound();
            //}

            //return blog;
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Blogs
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlog", new { id = blog.Id }, blog);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Blog>> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
