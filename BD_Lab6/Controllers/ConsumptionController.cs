using BD_Lab6.Data;
using BD_Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_Lab6.Controllers
{
    [Route("api/[controller]")]
    public class ConsumptionController : Controller
    {
        private readonly DbContextHome _db;
        public ConsumptionController(DbContextHome db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<List<Consumption>> GetAll()
        {
            return await _db.Consumptions.AsNoTracking().ToListAsync();
        }
        //GET :api/Consumptions/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consumption = await _db.Consumptions.FirstOrDefaultAsync(x => x.Id == id);

            if (consumption is null)
            {
                return NotFound();
            }

            return new ObjectResult(consumption);
        }

        //POST :api/consumptions
        [HttpPost]
        public async Task<IActionResult> Create(Consumption consumption)
        {
            if (consumption is null)
            {
                return BadRequest();
            }

            await _db.Consumptions.AddAsync(consumption);
            await _db.SaveChangesAsync();

            return Ok(consumption);
        }

        //POST :api/Consumptions/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var consumption = await _db.Consumptions.FirstOrDefaultAsync(x => x.Id == id);

            if (consumption is null)
            {
                return NotFound();
            }

            _db.Consumptions.Update(consumption);
            await _db.SaveChangesAsync();

            return Ok(consumption);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consumption = await _db.Consumptions.FirstOrDefaultAsync(x => x.Id == id);

            if (consumption is null)
            {
                return NotFound();
            }

            _db.Consumptions.Remove(consumption);
            await _db.SaveChangesAsync();

            return Ok(consumption);
        }
    }
}
