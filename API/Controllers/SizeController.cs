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

public class SizeController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SizeController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<SizeDto>>> Get()
    {
        var Size = await _unitOfWork.Sizes.GetAllAsync();
        return _mapper.Map<List<SizeDto>>(Size);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Sizes.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<SizeDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SizeDto>> Post(SizeDto SizeDto)
    {
        var Size = _mapper.Map<Size>(SizeDto);
        _unitOfWork.Sizes.Add(Size);
        await _unitOfWork.SaveAsync();
        if (Size == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Size.Id}, SizeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SizeDto>> Put(int id, [FromBody] SizeDto SizeDto)
    {
        if (SizeDto == null) return NotFound();
        var Size = _mapper.Map<Size>(SizeDto);
        _unitOfWork.Sizes.Update(Size);
        await _unitOfWork.SaveAsync();
        return SizeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Size = await _unitOfWork.Sizes.GetByIdAsync(id);
        if (Size == null) return NotFound();
        _unitOfWork.Sizes.Remove(Size);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}