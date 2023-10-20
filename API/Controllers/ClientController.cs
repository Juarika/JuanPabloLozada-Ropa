using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using API.Helpers;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class ClientController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userService = userService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
    {
        var Client = await _unitOfWork.Clients.GetAllAsync();
        return _mapper.Map<List<ClientDto>>(Client);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Clients.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<ClientDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Post(ClientDto ClientDto)
    {
        var Client = _mapper.Map<Client>(ClientDto);
        _unitOfWork.Clients.Add(Client);
        await _unitOfWork.SaveAsync();
        if (Client == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Client.Id}, ClientDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClientDto>> Put(int id, [FromBody] ClientDto ClientDto)
    {
        if (ClientDto == null) return NotFound();
        var Client = _mapper.Map<Client>(ClientDto);
        _unitOfWork.Clients.Update(Client);
        await _unitOfWork.SaveAsync();
        return ClientDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (Client == null) return NotFound();
        _unitOfWork.Clients.Remove(Client);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}