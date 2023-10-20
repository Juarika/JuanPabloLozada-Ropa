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

public class OrdenController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrdenController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<OrdenDto>>> Get()
    {
        var Orden = await _unitOfWork.Ordens.GetAllAsync();
        return _mapper.Map<List<OrdenDto>>(Orden);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Ordens.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<OrdenDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrdenDto>> Post(OrdenDto OrdenDto)
    {
        var Orden = _mapper.Map<Orden>(OrdenDto);
        _unitOfWork.Ordens.Add(Orden);
        await _unitOfWork.SaveAsync();
        if (Orden == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Orden.Id}, OrdenDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrdenDto>> Put(int id, [FromBody] OrdenDto OrdenDto)
    {
        if (OrdenDto == null) return NotFound();
        var Orden = _mapper.Map<Orden>(OrdenDto);
        _unitOfWork.Ordens.Update(Orden);
        await _unitOfWork.SaveAsync();
        return OrdenDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Orden = await _unitOfWork.Ordens.GetByIdAsync(id);
        if (Orden == null) return NotFound();
        _unitOfWork.Ordens.Remove(Orden);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}