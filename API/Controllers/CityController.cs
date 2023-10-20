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

public class CityController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CityController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<CityDto>>> Get()
    {
        var City = await _unitOfWork.Cities.GetAllAsync();
        return _mapper.Map<List<CityDto>>(City);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Cities.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<CityDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CityDto>> Post(CityDto CityDto)
    {
        var City = _mapper.Map<City>(CityDto);
        _unitOfWork.Cities.Add(City);
        await _unitOfWork.SaveAsync();
        if (City == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = City.Id}, CityDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CityDto>> Put(int id, [FromBody] CityDto CityDto)
    {
        if (CityDto == null) return NotFound();
        var City = _mapper.Map<City>(CityDto);
        _unitOfWork.Cities.Update(City);
        await _unitOfWork.SaveAsync();
        return CityDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var City = await _unitOfWork.Cities.GetByIdAsync(id);
        if (City == null) return NotFound();
        _unitOfWork.Cities.Remove(City);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}