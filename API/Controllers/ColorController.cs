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

public class ColorController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ColorController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<ColorDto>>> Get()
    {
        var Color = await _unitOfWork.Colors.GetAllAsync();
        return _mapper.Map<List<ColorDto>>(Color);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Colors.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<ColorDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ColorDto>> Post(ColorDto ColorDto)
    {
        var Color = _mapper.Map<Color>(ColorDto);
        _unitOfWork.Colors.Add(Color);
        await _unitOfWork.SaveAsync();
        if (Color == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Color.Id}, ColorDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ColorDto>> Put(int id, [FromBody] ColorDto ColorDto)
    {
        if (ColorDto == null) return NotFound();
        var Color = _mapper.Map<Color>(ColorDto);
        _unitOfWork.Colors.Update(Color);
        await _unitOfWork.SaveAsync();
        return ColorDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Color = await _unitOfWork.Colors.GetByIdAsync(id);
        if (Color == null) return NotFound();
        _unitOfWork.Colors.Remove(Color);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}