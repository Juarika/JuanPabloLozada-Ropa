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

public class SupplierController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SupplierController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<SupplierDto>>> Get()
    {
        var Supplier = await _unitOfWork.Suppliers.GetAllAsync();
        return _mapper.Map<List<SupplierDto>>(Supplier);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Suppliers.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<SupplierDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SupplierDto>> Post(SupplierDto SupplierDto)
    {
        var Supplier = _mapper.Map<Supplier>(SupplierDto);
        _unitOfWork.Suppliers.Add(Supplier);
        await _unitOfWork.SaveAsync();
        if (Supplier == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Supplier.Id}, SupplierDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SupplierDto>> Put(int id, [FromBody] SupplierDto SupplierDto)
    {
        if (SupplierDto == null) return NotFound();
        var Supplier = _mapper.Map<Supplier>(SupplierDto);
        _unitOfWork.Suppliers.Update(Supplier);
        await _unitOfWork.SaveAsync();
        return SupplierDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
        if (Supplier == null) return NotFound();
        _unitOfWork.Suppliers.Remove(Supplier);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }

    /* Listar los proveedores que sean persona natural. */
    [HttpGet("PersonType")]
    [MapToApiVersion("1.0")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<SupplierDto>>> GetForPersonType([FromQuery] Params _param)
    {
        var data = await _unitOfWork.Suppliers.GetForPersonType(_param.Search);
        var search = _mapper.Map<List<SupplierDto>>(data);
        return search;
    }
}