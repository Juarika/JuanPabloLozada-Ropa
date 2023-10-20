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

public class PositionController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PositionController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<PositionDto>>> Get()
    {
        var Position = await _unitOfWork.Positions.GetAllAsync();
        return _mapper.Map<List<PositionDto>>(Position);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Positions.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<PositionDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PositionDto>> Post(PositionDto PositionDto)
    {
        var Position = _mapper.Map<Position>(PositionDto);
        _unitOfWork.Positions.Add(Position);
        await _unitOfWork.SaveAsync();
        if (Position == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Position.Id}, PositionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PositionDto>> Put(int id, [FromBody] PositionDto PositionDto)
    {
        if (PositionDto == null) return NotFound();
        var Position = _mapper.Map<Position>(PositionDto);
        _unitOfWork.Positions.Update(Position);
        await _unitOfWork.SaveAsync();
        return PositionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Position = await _unitOfWork.Positions.GetByIdAsync(id);
        if (Position == null) return NotFound();
        _unitOfWork.Positions.Remove(Position);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}