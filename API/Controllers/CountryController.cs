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

public class CountryController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var Country = await _unitOfWork.Countries.GetAllAsync();
        return _mapper.Map<List<CountryDto>>(Country);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Countries.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<CountryDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Post(CountryDto CountryDto)
    {
        var Country = _mapper.Map<Country>(CountryDto);
        _unitOfWork.Countries.Add(Country);
        await _unitOfWork.SaveAsync();
        if (Country == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Country.Id}, CountryDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto CountryDto)
    {
        if (CountryDto == null) return NotFound();
        var Country = _mapper.Map<Country>(CountryDto);
        _unitOfWork.Countries.Update(Country);
        await _unitOfWork.SaveAsync();
        return CountryDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (Country == null) return NotFound();
        _unitOfWork.Countries.Remove(Country);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}