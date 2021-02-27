using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("categories")]
    public class CategoryController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            return new List<Category>();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            return new Category();
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar a categoria."});
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Category>> Put(int id, [FromBody] Category model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria, erro de concorrência" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar a categoria."});
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Category>> Delete(int id, [FromServices] DataContext context)
        {
            //recuperar a categoria do banco
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
                return NotFound(new {message  = "Categoria não encontrada" });

            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new { message = "Categoria removida com sucesso." });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível excluir registro" });
            }
        }
    }
}
