using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Antibody.UnbrandedAcneMicrosite.Models.unbranded;

namespace Antibody.UnbrandedAcneMicrosite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVideoProgressesController : ControllerBase
    {
        private readonly DB_Antibody_UnbrandedContext _context;

        public UserVideoProgressesController(DB_Antibody_UnbrandedContext context)
        {
            _context = context;
        }

        // GET: api/UserVideoProgresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserVideoProgress>>> GetUserVideoProgresses()
        {
            return await _context.UserVideoProgresses.ToListAsync();
        }

        // GET: api/UserVideoProgresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVideoProgress>> GetUserVideoProgress(int id)
        {
            var userVideoProgress = await _context.UserVideoProgresses.FindAsync(id);

            if (userVideoProgress == null)
            {
                return NotFound();
            }

            return userVideoProgress;
        }

        // PUT: api/UserVideoProgresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserVideoProgress(int id, UserVideoProgress userVideoProgress)
        {
            if (id != userVideoProgress.VideoProgressId)
            {
                return BadRequest();
            }

            _context.Entry(userVideoProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserVideoProgressExists(id))
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

        // POST: api/UserVideoProgresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserVideoProgress>> PostUserVideoProgress(string UserId,int progressTime,int videoId)
        {
            if (progressTime <= 0)
            {
                return Ok();
            }
            try
            {

                if (UserId.ToString().Length < 1)
                {
                    return BadRequest("User not found");
                }

                UserVideoProgress userVideoProgress = new UserVideoProgress()
                {
                    UserGuid = Guid.Parse(UserId),
                    ProgressSecond = progressTime,
                    DateUpdated = DateTime.Now,
                    VideoId = videoId,
                };


                var progress = _context.UserVideoProgresses.FirstOrDefault(x => x.UserGuid == userVideoProgress.UserGuid && x.VideoId == userVideoProgress.VideoId);

                if (progress == null)
                {
                    //insert new progress
                    _context.UserVideoProgresses.Add(userVideoProgress);
                }
                else
                {
                    progress.ProgressSecond = userVideoProgress.ProgressSecond;
                    progress.DateUpdated = DateTime.Now;
                    //update progress table
                }


                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // DELETE: api/UserVideoProgresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserVideoProgress(int id)
        {
            var userVideoProgress = await _context.UserVideoProgresses.FindAsync(id);
            if (userVideoProgress == null)
            {
                return NotFound();
            }

            _context.UserVideoProgresses.Remove(userVideoProgress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserVideoProgressExists(int id)
        {
            return _context.UserVideoProgresses.Any(e => e.VideoProgressId == id);
        }
    }
}
