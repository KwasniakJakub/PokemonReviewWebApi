using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : Controller
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public OwnerController(IOwnerRepository ownerRepository,
        ICountryRepository countryRepository,
        IMapper mapper)
    {
        _ownerRepository = ownerRepository;
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
    public IActionResult GetOwners()
    {
        var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(owners);
    }

    [HttpGet("{ownerId}")]
    [ProducesResponseType(200, Type = typeof(Owner))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonByOwner(int ownerId)
    {
        if (!_ownerRepository.OwnerExist(ownerId))
            return NotFound();

        var owner = _mapper.Map<List<PokemonDto>>(
            _ownerRepository.GetPokemonByOwner(ownerId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(owner);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateOwner([FromBody] int countryId, [FromBody] OwnerDto ownerCreate)
    {
        if (ownerCreate == null)
            return BadRequest(ModelState);

        var owner = _ownerRepository.GetOwners()
            .Where(c => c.LastName.Trim().ToUpper() == ownerCreate.LastName
            .TrimEnd().ToUpper())
            .FirstOrDefault();

        if (owner != null)
        {
            ModelState.AddModelError("", "Country already exist");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var ownerMap = _mapper.Map<Owner>(ownerCreate);

        ownerMap.Country = _countryRepository.GetCountry(countryId);

        if (!_ownerRepository.CreateOwner(ownerMap))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Succesfully created");
    }
}