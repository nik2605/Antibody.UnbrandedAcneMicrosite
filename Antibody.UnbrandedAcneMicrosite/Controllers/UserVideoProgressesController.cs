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
        private readonly db_antibody_unbrandedContext _context;

        public UserVideoProgressesController(db_antibody_unbrandedContext context)
        {
            _context = context;
        }

        // GET: api/UserVideoProgresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uservideoprogress>>> GetUserVideoProgresses()
        {
            return await _context.Uservideoprogresses.ToListAsync();
        }

        // GET: api/UserVideoProgresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uservideoprogress>> GetUserVideoProgress(int id)
        {
            var userVideoProgress = await _context.Uservideoprogresses.FindAsync(id);

            if (userVideoProgress == null)
            {
                return NotFound();
            }

            return userVideoProgress;
        }

        // PUT: api/UserVideoProgresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserVideoProgress(int id, Uservideoprogress userVideoProgress)
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
        public async Task<ActionResult<Uservideoprogress>> PostUserVideoProgress(string UserId,int progressTime,int videoId)
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

                Uservideoprogress userVideoProgress = new Uservideoprogress()
                {
                    UserGuid = UserId,
                    ProgressSecond = progressTime,
                    DateUpdated = DateTime.Now,
                    VideoId = videoId,
                };


                var progress = _context.Uservideoprogresses.FirstOrDefault(x => x.UserGuid == userVideoProgress.UserGuid && x.VideoId == userVideoProgress.VideoId);

                if (progress == null)
                {
                    //insert new progress
                    _context.Uservideoprogresses.Add(userVideoProgress);
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
            var userVideoProgress = await _context.Uservideoprogresses.FindAsync(id);
            if (userVideoProgress == null)
            {
                return NotFound();
            }

            _context.Uservideoprogresses.Remove(userVideoProgress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserVideoProgressExists(int id)
        {
            return _context.Uservideoprogresses.Any(e => e.VideoProgressId == id);
        }
    }
}
