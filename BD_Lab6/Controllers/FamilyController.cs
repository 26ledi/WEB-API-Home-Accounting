using BD_Lab6.Data;
using BD_Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_Lab6.Controllers
{
    [Route("api/[controller]")]
    public class FamilyController : Controller
    {
        private readonly DbContextHome _db;
        public FamilyController(DbContextHome db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Family>> GetAll()
        {
            return await _db.Families.AsNoTracking().ToListAsync();
        }
        //GET :api/Family/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var family = await _db.Families.FirstOrDefaultAsync(x => x.Id == id);

            if (family is null)
            {
                return NotFound();
            }

            return new ObjectResult(family);
        }

        //POST :api/Family
        [HttpPost]
        public async Task<IActionResult> Create(Family family)
        {
            if (family is null)
            {
                return BadRequest();
            }

            await _db.Families.AddAsync(family);
            await _db.SaveChangesAsync();

            return Ok(family);
        }

        //POST :api/Family/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var family = await _db.Families.FirstOrDefaultAsync(x => x.Id == id);

            if (family is null)
            {
                return NotFound();
            }

            _db.Families.Update(family);
            await _db.SaveChangesAsync();

            return Ok(family);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var family = await _db.Families.FirstOrDefaultAsync(x => x.Id == id);

            if (family is null)
            {
                return NotFound();
            }

            _db.Families.Remove(family);
            await _db.SaveChangesAsync();

            return Ok(family);
        }
    }
}
