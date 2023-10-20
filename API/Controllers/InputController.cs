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

public class InputController : ApiBaseController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InputController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
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
    public async Task<ActionResult<IEnumerable<InputDto>>> Get()
    {
        var Input = await _unitOfWork.Inputs.GetAllAsync();
        return _mapper.Map<List<InputDto>>(Input);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    // [Authorize(Roles = "Administrator, Employee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<object> Get([FromQuery] Params queryParams)
    {
        var paginated = await _unitOfWork.Inputs.GetWithPagination(queryParams.PageIndex, queryParams.PageSize);
        return _mapper.Map<List<InputDto>>(paginated);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InputDto>> Post(InputDto InputDto)
    {
        var Input = _mapper.Map<Input>(InputDto);
        _unitOfWork.Inputs.Add(Input);
        await _unitOfWork.SaveAsync();
        if (Input == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post),new {id = Input.Id}, InputDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InputDto>> Put(int id, [FromBody] InputDto InputDto)
    {
        if (InputDto == null) return NotFound();
        var Input = _mapper.Map<Input>(InputDto);
        _unitOfWork.Inputs.Update(Input);
        await _unitOfWork.SaveAsync();
        return InputDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var Input = await _unitOfWork.Inputs.GetByIdAsync(id);
        if (Input == null) return NotFound();
        _unitOfWork.Inputs.Remove(Input);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}