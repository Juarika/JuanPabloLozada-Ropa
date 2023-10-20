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

public class DressController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DressController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<DressDto>>> Get()
    {
        var Dress = await _unitOfWork.Dresses.GetAllAsync();
        return _mapper.Map<List<DressDto>>(Dress);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Dresses.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<DressDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DressDto>> Post(DressDto DressDto)
    {
        var Dress = _mapper.Map<Dress>(DressDto);
        _unitOfWork.Dresses.Add(Dress);
        await _unitOfWork.SaveAsync();
        if (Dress == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Dress.Id}, DressDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DressDto>> Put(int id, [FromBody] DressDto DressDto)
    {
        if (DressDto == null) return NotFound();
        var Dress = _mapper.Map<Dress>(DressDto);
        _unitOfWork.Dresses.Update(Dress);
        await _unitOfWork.SaveAsync();
        return DressDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Dress = await _unitOfWork.Dresses.GetByIdAsync(id);
        if (Dress == null) return NotFound();
        _unitOfWork.Dresses.Remove(Dress);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}