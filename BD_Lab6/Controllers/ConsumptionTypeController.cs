using BD_Lab6.Data;
using BD_Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BD_Lab6.Controllers
{
    [Route("api/[controller]")]
    public class ConsumptionTypeController : Controller
    {
        private readonly DbContextHome _db;
        public ConsumptionTypeController(DbContextHome db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<List<ConsumptionType>> GetAll()
        {
            return await _db.ConsumptionTypes.AsNoTracking().ToListAsync();
        }
        //GET :api/ConsumptionType/10
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consumptionType = await _db.ConsumptionTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (consumptionType is null)
            {
                return NotFound();
            }

            return new ObjectResult(consumptionType);
        }

        //POST :api/consumptionType
        [HttpPost]
        public async Task<IActionResult> Create(ConsumptionType consumptionType)
        {
            if (consumptionType is null)
            {
                return BadRequest();
            }

            await _db.ConsumptionTypes.AddAsync(consumptionType);
            await _db.SaveChangesAsync();

            return Ok(consumptionType);
        }

        //POST :api/ConsumptionType/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var consumptionType = await _db.ConsumptionTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (consumptionType is null)
            {
                return NotFound();
            }

            _db.ConsumptionTypes.Update(consumptionType);
            await _db.SaveChangesAsync();

            return Ok(consumptionType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var consumptionType = await _db.ConsumptionTypes.FirstOrDefaultAsync(x => x.Id == id);

            if (consumptionType is null)
            {
                return NotFound();
            }

            _db.ConsumptionTypes.Remove(consumptionType);
            await _db.SaveChangesAsync();

            return Ok(consumptionType);
        }
    }
}
