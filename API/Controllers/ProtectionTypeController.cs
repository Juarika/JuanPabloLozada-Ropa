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

public class ProtectionTypeController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProtectionTypeController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<ProtectionTypeDto>>> Get()
    {
        var ProtectionType = await _unitOfWork.ProtectionTypes.GetAllAsync();
        return _mapper.Map<List<ProtectionTypeDto>>(ProtectionType);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.ProtectionTypes.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<ProtectionTypeDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProtectionTypeDto>> Post(ProtectionTypeDto ProtectionTypeDto)
    {
        var ProtectionType = _mapper.Map<ProtectionType>(ProtectionTypeDto);
        _unitOfWork.ProtectionTypes.Add(ProtectionType);
        await _unitOfWork.SaveAsync();
        if (ProtectionType == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = ProtectionType.Id}, ProtectionTypeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProtectionTypeDto>> Put(int id, [FromBody] ProtectionTypeDto ProtectionTypeDto)
    {
        if (ProtectionTypeDto == null) return NotFound();
        var ProtectionType = _mapper.Map<ProtectionType>(ProtectionTypeDto);
        _unitOfWork.ProtectionTypes.Update(ProtectionType);
        await _unitOfWork.SaveAsync();
        return ProtectionTypeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var ProtectionType = await _unitOfWork.ProtectionTypes.GetByIdAsync(id);
        if (ProtectionType == null) return NotFound();
        _unitOfWork.ProtectionTypes.Remove(ProtectionType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    /* Listar las prendas agrupadas por el tipo de protección. */
    [HttpGet("ProtectionType")]
    [MapToApiVersion("1.0")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> GetForSpecie([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.ProtectionTypes.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<ProtectionTypeDto>>(paginated);
    }
}