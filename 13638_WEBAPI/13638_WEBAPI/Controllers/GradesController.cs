using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _13638_WEBAPI.Data;
using _13638_WEBAPI.Models;
using _13638_WEBAPI.Repositories;
using System.Security.Policy;

namespace _13638_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IRepository<Grade> _repository;
        public GradesController(IRepository<Grade> repository)
        {
            _repository = repository;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<IEnumerable<Grade>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _repository.GetByIDAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // PUT: api/Grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Grade grade)
        {
            //if(id!=items.ID) return BadRequest();
            await _repository.UpdateAsync(grade);
            return NoContent();
        }

        // POST: api/Grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Create(Grade grades)
        {
            await _repository.AddAsync(grades);
            return CreatedAtAction(nameof(GetByID), new { id = grades.ID }, grades);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
