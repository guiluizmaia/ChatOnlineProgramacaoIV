using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.persistence;
using backend.models;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers
{
    [ApiController]
    [Route("messages")]
    public class AlunoController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Message>>> Get([FromServices] Context context)
        {
            var msgs = await context.Message.ToListAsync();
            return Ok(msgs);
        }

        [HttpGet]
        [Route("id/{id:int}")]
        public async Task<ActionResult<List<Message>>> GetAluno([FromServices] Context context, int id)
        {
            var msg = await context.Message
                              .AsNoTracking()
                              .FirstOrDefaultAsync(a => a.Id == id);
            return Ok(msg);
        }

        [HttpGet]
        [Route("mail/{mail}")]
        public async Task<ActionResult<List<Message>>> GetAluno([FromServices] Context context, string mail)
        {
            var msgs = await context.Message
                              .ToListAsync();

            List<Message> res = new List<Message>();

            foreach (var msg in msgs)
            {
                if (msg.mail == mail)
                {
                    res.Add(msg);
                }
            }

            return Ok(res);
        }



        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Message>> Post([FromServices] Context context,
        [FromBody] Message msg)
        {
            if (ModelState.IsValid)
            {
                context.Message.Add(msg);
                await context.SaveChangesAsync();

                return msg;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}