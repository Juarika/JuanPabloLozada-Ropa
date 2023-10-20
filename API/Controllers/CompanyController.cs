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

public class CompanyController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CompanyController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<CompanyDto>>> Get()
    {
        var Company = await _unitOfWork.Companies.GetAllAsync();
        return _mapper.Map<List<CompanyDto>>(Company);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Companies.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<CompanyDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CompanyDto>> Post(CompanyDto CompanyDto)
    {
        var Company = _mapper.Map<Company>(CompanyDto);
        _unitOfWork.Companies.Add(Company);
        await _unitOfWork.SaveAsync();
        if (Company == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Company.Id}, CompanyDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CompanyDto>> Put(int id, [FromBody] CompanyDto CompanyDto)
    {
        if (CompanyDto == null) return NotFound();
        var Company = _mapper.Map<Company>(CompanyDto);
        _unitOfWork.Companies.Update(Company);
        await _unitOfWork.SaveAsync();
        return CompanyDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Company = await _unitOfWork.Companies.GetByIdAsync(id);
        if (Company == null) return NotFound();
        _unitOfWork.Companies.Remove(Company);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}