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

public class InventaryController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InventaryController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<InventaryDto>>> Get()
    {
        var Inventary = await _unitOfWork.Inventories.GetAllAsync();
        return _mapper.Map<List<InventaryDto>>(Inventary);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Inventories.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<InventaryDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InventaryDto>> Post(InventaryDto InventaryDto)
    {
        var Inventary = _mapper.Map<Inventary>(InventaryDto);
        _unitOfWork.Inventories.Add(Inventary);
        await _unitOfWork.SaveAsync();
        if (Inventary == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Inventary.Id}, InventaryDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InventaryDto>> Put(int id, [FromBody] InventaryDto InventaryDto)
    {
        if (InventaryDto == null) return NotFound();
        var Inventary = _mapper.Map<Inventary>(InventaryDto);
        _unitOfWork.Inventories.Update(Inventary);
        await _unitOfWork.SaveAsync();
        return InventaryDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Inventary = await _unitOfWork.Inventories.GetByIdAsync(id);
        if (Inventary == null) return NotFound();
        _unitOfWork.Inventories.Remove(Inventary);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}