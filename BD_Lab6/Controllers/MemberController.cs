using BD_Lab6.Data;
using BD_Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_Lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MemberController : Controller
    {
        private readonly DbContextHome _db;
        public MemberController(DbContextHome db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Member>> GetMembers()
        {
            return await _db.Members.AsNoTracking().ToListAsync();
        }
        //GET :api/Member/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _db.Members.FirstOrDefaultAsync(x => x.Id == id);

            if (member is null)
            {
                return NotFound();
            }

            return new ObjectResult(member);
        }

        //POST :api/Members
        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            if (member is null)
            {
                return BadRequest();
            }

            await _db.Members.AddAsync(member);
            await _db.SaveChangesAsync();

            return Ok(member);
        }

        //POST :api/Member/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Member updatedMember)
        {
            var member = await _db.Members.FirstOrDefaultAsync(x => x.Id == id);

            if (member is null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés du membre existant avec les nouvelles valeurs
            member.Name = updatedMember.Name;
            member.Surname = updatedMember.Surname;
            member.Birthday = updatedMember.Birthday;
            member.FamilyId = updatedMember.FamilyId;

            _db.Members.Update(member);
            await _db.SaveChangesAsync();

            return Ok(member);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _db.Members.FirstOrDefaultAsync(x => x.Id == id);

            if (member is null)
            {
                return NotFound();
            }

            _db.Members.Remove(member);
            await _db.SaveChangesAsync();

            return Ok(member);
        }
    }
}
