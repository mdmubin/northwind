﻿namespace Api.Services.DataServices;

public interface IDataServiceManager
{
    public ItemService ItemService { get; }
    public OrderService OrderService { get; }
    public AuthService AuthService { get; }
}