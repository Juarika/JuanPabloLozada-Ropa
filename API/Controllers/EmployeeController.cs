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

public class EmployeeController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
    {
        var Employee = await _unitOfWork.Employees.GetAllAsync();
        return _mapper.Map<List<EmployeeDto>>(Employee);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Employees.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<EmployeeDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmployeeDto>> Post(EmployeeDto EmployeeDto)
    {
        var Employee = _mapper.Map<Employee>(EmployeeDto);
        _unitOfWork.Employees.Add(Employee);
        await _unitOfWork.SaveAsync();
        if (Employee == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Employee.Id}, EmployeeDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmployeeDto>> Put(int id, [FromBody] EmployeeDto EmployeeDto)
    {
        if (EmployeeDto == null) return NotFound();
        var Employee = _mapper.Map<Employee>(EmployeeDto);
        _unitOfWork.Employees.Update(Employee);
        await _unitOfWork.SaveAsync();
        return EmployeeDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Employee = await _unitOfWork.Employees.GetByIdAsync(id);
        if (Employee == null) return NotFound();
        _unitOfWork.Employees.Remove(Employee);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}