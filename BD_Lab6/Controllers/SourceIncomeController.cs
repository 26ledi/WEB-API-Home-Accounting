using BD_Lab6.Data;
using BD_Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_Lab6.Controllers
{
    [Route("api/[controller]")]
    public class SourceIncomeController : Controller
    {
        private readonly DbContextHome _db;
        public SourceIncomeController(DbContextHome db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<SourceIncome>> GetMembers()
        {
            return await _db.SourceIncomes.AsNoTracking().ToListAsync();
        }
        //GET :api/SourceIncome/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sourceIncome = await _db.SourceIncomes.FirstOrDefaultAsync(x => x.Id == id);

            if (sourceIncome is null)
            {
                return NotFound();
            }

            return new ObjectResult(sourceIncome);
        }

        //POST :api/SourceIncome
        [HttpPost]
        public async Task<IActionResult> Create(SourceIncome sourceIncome)
        {
            if (sourceIncome is null)
            {
                return BadRequest();
            }

            await _db.SourceIncomes.AddAsync(sourceIncome);
            await _db.SaveChangesAsync();

            return Ok(sourceIncome);
        }

        //POST :api/Member/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var sourceIncome = await _db.SourceIncomes.FirstOrDefaultAsync(x => x.Id == id);

            if (sourceIncome is null)
            {
                return NotFound();
            }

            _db.SourceIncomes.Update(sourceIncome);
            await _db.SaveChangesAsync();

            return Ok(sourceIncome);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sourceIncome = await _db.SourceIncomes.FirstOrDefaultAsync(x => x.Id == id);

            if (sourceIncome is null)
            {
                return NotFound();
            }

            _db.SourceIncomes.Remove(sourceIncome);
            await _db.SaveChangesAsync();

            return Ok(sourceIncome);
        }
    }
}
