using AutoMapper;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository;

public class CountryRepository : ICountryRepository
{
    private readonly DataContext _contex;
    private readonly IMapper _mapper;

    public CountryRepository(DataContext contex, IMapper mapper)
    {
        _contex = contex;
        _mapper = mapper;
    }
    public ICollection<Country> GetCountries()
    {
        return _contex.Countries.ToList();
    }

    public Country GetCountry(int id)
    {
        return _contex.Countries.Where(c => c.Id == id).FirstOrDefault();
    }

    public Country GetCountryByOwner(int ownerId)
    {
        return _contex.Owners.Where(o => o.Id == ownerId).Select(c => c.Country).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnersFromCountry(int countryId)
    {
        return _contex.Owners.Where(c => c.Country.Id == countryId).ToList();
    }

    public bool CountryExist(int id)
    {
        return _contex.Countries.Any(c => c.Id == id);
    }

    public bool CreateCountry(Country country)
    {
        _contex.Add(country);
        return Save();
    }

    public bool UpdateCountry(Country country)
    {
        _contex.Update(country);
        return Save();
    }

    public bool DeleteCountry(Country country)
    {
        _contex.Remove(country);
        return Save();
    }

    public bool Save()
    {
        var saved = _contex.SaveChanges();
        return saved > 0 ? true : false;
    }
}