using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UC_WebApi.Context;

namespace UC_WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly ApplicationDbContext context;

    public ClientController(ApplicationDbContext context)
    {
        this.context = context;
    }

    [HttpGet("listar")]
    public async Task<ActionResult<Client>> GetAll() 
        => Ok(await this.context.Clients.ToListAsync());

    [HttpPost("cadastrar")]
    public async Task<ActionResult<Client>> Post([FromBody] Client client) {
        if (!ModelState.IsValid)
            return BadRequest();

        this.context.Add(client);
        return Ok(await this.context.SaveChangesAsync());
    }

    [HttpPut("atualizar/{id:int}")]
    public async Task<ActionResult<Client>> Put(Client client, int id) {
        var cliente = await this.context.Clients.FindAsync(id);

        if (cliente == null)
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();
        
        cliente.Nome = client.Nome;
        cliente.Telefone = client.Telefone;
        cliente.DataNascimento = client.DataNascimento;

        this.context.Clients.Update(cliente);
        return Ok(await this.context.SaveChangesAsync());
    }

    [HttpDelete("remover/{id:int}")]
    public async Task<ActionResult<Client>> Delete(int id) {
        var cliente = await this.context.Clients.FindAsync(id);
        this.context.Clients.Remove(cliente);
        return Ok(await this.context.SaveChangesAsync());
    }

}

