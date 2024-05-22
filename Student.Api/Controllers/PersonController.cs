using Microsoft.AspNetCore.Mvc;
using Student.Api.Interfaces;
using Student.Api.Models;

namespace Student.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository _service;

    public PersonController(IPersonRepository personRepository)
    {
        _service = personRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _service.GetAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Person person)
    {
        var result = await _service.AddAsync(person);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Person person)
    {
        var result = await _service.UpdateAsync(person);
        return Ok(result);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        return Ok(result);
    }
}
