using Api.Data.Repositories;
using Api.Entities;
using Api.Services.Logging;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Api.Services.DataServices;

public class DataServiceManager : IDataServiceManager
{
    private readonly Lazy<ItemService> _itemService;

    private readonly Lazy<OrderService> _orderService;

    private readonly Lazy<AuthService> _authService;

    public DataServiceManager(IRepositoryManager repositoryManager, IMapper mapper, ILogService logger,
        UserManager<User> userManager, IConfiguration appConfig)
    {
        _itemService = new Lazy<ItemService>(new ItemService(repositoryManager, mapper, logger));
        _orderService = new Lazy<OrderService>(new OrderService(repositoryManager, mapper, logger));
        _authService = new Lazy<AuthService>(new AuthService(userManager, mapper, logger, appConfig));
    }

    public ItemService ItemService => _itemService.Value;
    public OrderService OrderService => _orderService.Value;
    public AuthService AuthService => _authService.Value;
}