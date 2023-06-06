﻿using Api.Data.Repositories;
using Api.Services.Logging;
using AutoMapper;

namespace Api.Services.DataServices;

public class DataServiceManager : IDataServiceManager
{
    private readonly Lazy<ItemService> _itemService;

    public DataServiceManager(IRepositoryManager repositoryManager, IMapper mapper, ILogService logger)
    {
        _itemService = new Lazy<ItemService>(new ItemService(repositoryManager, mapper, logger));
    }

    public ItemService ItemService => _itemService.Value;
}