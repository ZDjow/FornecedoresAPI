using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FornecedoresPM.Modelos;

[Route("api/fornecedores")]
[ApiController]
public class FornecedorController : ControllerBase
{
    private readonly FornecedoresDB FornecedoresDB;

    public FornecedorController(FornecedoresDB context)
    {
        FornecedoresDB = context;
    }

    //GET api/fornecedores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
    {
        return await FornecedoresDB.Fornecedores.ToListAsync();
    }

    //GET api/fornecedores/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
    {
        var fornecedor = await FornecedoresDB.Fornecedores.FindAsync(id);

        if (fornecedor == null)
            return NotFound("Fornecedor não encontrado.");

        return fornecedor;
    }

    //POST api/fornecedores
    [HttpPost]
    public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        FornecedoresDB.Fornecedores.Add(fornecedor);
        await FornecedoresDB.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
    }

    //PUT api/fornecedores/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
    {        
        var fornecedorExistente = await FornecedoresDB.Fornecedores.FindAsync(id);

        if (fornecedorExistente == null)
            return NotFound("Fornecedor não encontrado.");

        AtualizaDadosFornecedor(fornecedorExistente, fornecedor);               

        FornecedoresDB.Entry(fornecedorExistente).State = EntityState.Modified;

        try
        {            
            await FornecedoresDB.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {            
            return StatusCode(500, "Erro ao tentar atualizar o fornecedor.");
        }

        return NoContent();
    }

    private void AtualizaDadosFornecedor(Fornecedor fornecedorExistente, Fornecedor fornecedor)
    {
        foreach (var propriedade in fornecedor.GetType().GetProperties())
        {
            if (propriedade.Name == "Id" || propriedade.GetValue(fornecedor) == null)
                continue;

            var valorExistente = propriedade.GetValue(fornecedorExistente);
            var valorNovo = propriedade.GetValue(fornecedor);

            if (valorNovo != null && !valorNovo.Equals(valorExistente))            
                propriedade.SetValue(fornecedorExistente, valorNovo);          
        }
    }

    //DELETE api/fornecedores/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFornecedor(int id)
    {
        var fornecedor = await FornecedoresDB.Fornecedores.FindAsync(id);

        if (fornecedor == null)
            return NotFound("Fornecedor não encontrado.");

        FornecedoresDB.Fornecedores.Remove(fornecedor);
        await FornecedoresDB.SaveChangesAsync();

        return NoContent();
    }
    
}
