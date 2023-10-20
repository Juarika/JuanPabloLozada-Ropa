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

public class GenderController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenderController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<GenderDto>>> Get()
    {
        var Gender = await _unitOfWork.Genders.GetAllAsync();
        return _mapper.Map<List<GenderDto>>(Gender);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Genders.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<GenderDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenderDto>> Post(GenderDto GenderDto)
    {
        var Gender = _mapper.Map<Gender>(GenderDto);
        _unitOfWork.Genders.Add(Gender);
        await _unitOfWork.SaveAsync();
        if (Gender == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Gender.Id}, GenderDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GenderDto>> Put(int id, [FromBody] GenderDto GenderDto)
    {
        if (GenderDto == null) return NotFound();
        var Gender = _mapper.Map<Gender>(GenderDto);
        _unitOfWork.Genders.Update(Gender);
        await _unitOfWork.SaveAsync();
        return GenderDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Gender = await _unitOfWork.Genders.GetByIdAsync(id);
        if (Gender == null) return NotFound();
        _unitOfWork.Genders.Remove(Gender);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}