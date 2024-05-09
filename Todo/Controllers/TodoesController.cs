﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Controllers
{
    [Route("todo/api/v1/[controller]")]
    [ApiController]
    public class TodoesController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoesController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Todoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo.Models.Todo>>> GetJournals()
        {
            return await _context.Todoes.ToListAsync();
        }

        // GET: api/Todoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo.Models.Todo>> GetTodo(int id)
        {
            var todo = await _context.Todoes.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // PUT: api/Todoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo.Models.Todo todo)
        {
            if (id != todo.TodoId)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
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

        // POST: api/Todoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Todo.Models.Todo>> PostTodo(Todo.Models.Todo todo)
        {
            _context.Todoes.Add(todo);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodo", new { id = todo.TodoId }, todo);
            return CreatedAtAction(nameof(GetTodo), new { id = todo.TodoId }, todo);

        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.Todoes.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todoes.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoExists(int id)
        {
            return _context.Todoes.Any(e => e.TodoId == id);
        }
    }
}
