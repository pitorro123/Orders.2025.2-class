﻿using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Share.DTOs;
using Orders.Share.Entities;
using Orders.Share.Responses;

namespace Orders.Backend.UnitsOfWork.Implementations;

public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
{
    private readonly ICountriesRepository _countriesRepository;

    public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository
        countryRepository) : base(repository)
    {
        _countriesRepository = countryRepository;
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await
        _countriesRepository.GetTotalRecordsAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination) => await
        _countriesRepository.GetAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await
        _countriesRepository.GetAsync();

    public override async Task<ActionResponse<Country>> GetAsync(int id) => await
        _countriesRepository.GetAsync(id);
}