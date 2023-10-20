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

public class StateController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StateController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<StateDto>>> Get()
    {
        var State = await _unitOfWork.States.GetAllAsync();
        return _mapper.Map<List<StateDto>>(State);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.States.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<StateDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StateDto>> Post(StateDto StateDto)
    {
        var State = _mapper.Map<State>(StateDto);
        _unitOfWork.States.Add(State);
        await _unitOfWork.SaveAsync();
        if (State == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = State.Id}, StateDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StateDto>> Put(int id, [FromBody] StateDto StateDto)
    {
        if (StateDto == null) return NotFound();
        var State = _mapper.Map<State>(StateDto);
        _unitOfWork.States.Update(State);
        await _unitOfWork.SaveAsync();
        return StateDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var State = await _unitOfWork.States.GetByIdAsync(id);
        if (State == null) return NotFound();
        _unitOfWork.States.Remove(State);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}