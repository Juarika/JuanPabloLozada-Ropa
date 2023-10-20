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

public class StatusController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StatusController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<StatusDto>>> Get()
    {
        var Status = await _unitOfWork.Statuses.GetAllAsync();
        return _mapper.Map<List<StatusDto>>(Status);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Statuses.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<StatusDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StatusDto>> Post(StatusDto StatusDto)
    {
        var Status = _mapper.Map<Status>(StatusDto);
        _unitOfWork.Statuses.Add(Status);
        await _unitOfWork.SaveAsync();
        if (Status == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Status.Id}, StatusDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StatusDto>> Put(int id, [FromBody] StatusDto StatusDto)
    {
        if (StatusDto == null) return NotFound();
        var Status = _mapper.Map<Status>(StatusDto);
        _unitOfWork.Statuses.Update(Status);
        await _unitOfWork.SaveAsync();
        return StatusDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Status = await _unitOfWork.Statuses.GetByIdAsync(id);
        if (Status == null) return NotFound();
        _unitOfWork.Statuses.Remove(Status);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}