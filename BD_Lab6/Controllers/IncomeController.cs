using BD_Lab6.Data;
using BD_Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_Lab6.Controllers
{
    [Route("api/[controller]")]
    public class IncomeController : Controller
    {
        private readonly DbContextHome _db;
        public IncomeController(DbContextHome db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Income>> GetAll()
        {
            return await _db.Incomes.AsNoTracking().ToListAsync();
        }
        //GET :api/Income/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var income = await _db.Incomes.FirstOrDefaultAsync(x => x.Id == id);

            if (income is null)
            {
                return NotFound();
            }

            return new ObjectResult(income);
        }

        //POST :api/Family
        [HttpPost]
        public async Task<IActionResult> Create(Income income)
        {
            if (income is null)
            {
                return BadRequest();
            }

            await _db.Incomes.AddAsync(income);
            await _db.SaveChangesAsync();

            return Ok(income);
        }

        //POST :api/Income/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var income = await _db.Incomes.FirstOrDefaultAsync(x => x.Id == id);

            if (income is null)
            {
                return NotFound();
            }

            _db.Incomes.Update(income);
            await _db.SaveChangesAsync();

            return Ok(income);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var income = await _db.Incomes.FirstOrDefaultAsync(x => x.Id == id);

            if (income is null)
            {
                return NotFound();
            }

            _db.Incomes.Remove(income);
            await _db.SaveChangesAsync();

            return Ok(income);
        }
    }
}
