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

namespace _13638_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository<Student> _repository;
        public StudentsController(IRepository<Student> repo)
        {
            _repository = repo;
        }

        // GET: api/Students
        [HttpGet]

        public async Task<IEnumerable<Student>> GetAll() => await _repository.GetAllAsync();

        // GET: api/Students/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _repository.GetByIDAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Student items)
        {
            //if(id!=items.ID) return BadRequest();
            await _repository.UpdateAsync(items);
            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Student items)
        {
            await _repository.AddAsync(items);
            return Ok(items);
            //return CreatedAtAction(nameof(GetByID), new { id = items.ID }, items);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
