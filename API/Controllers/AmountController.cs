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

public class AmountController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AmountController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<AmountDto>>> Get()
    {
        var Amount = await _unitOfWork.Amounts.GetAllAsync();
        return _mapper.Map<List<AmountDto>>(Amount);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Amounts.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<AmountDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AmountDto>> Post(AmountDto AmountDto)
    {
        var Amount = _mapper.Map<Amount>(AmountDto);
        _unitOfWork.Amounts.Add(Amount);
        await _unitOfWork.SaveAsync();
        if (Amount == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Amount.Id}, AmountDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AmountDto>> Put(int id, [FromBody] AmountDto AmountDto)
    {
        if (AmountDto == null) return NotFound();
        var Amount = _mapper.Map<Amount>(AmountDto);
        _unitOfWork.Amounts.Update(Amount);
        await _unitOfWork.SaveAsync();
        return AmountDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Amount = await _unitOfWork.Amounts.GetByIdAsync(id);
        if (Amount == null) return NotFound();
        _unitOfWork.Amounts.Remove(Amount);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}