using App.Interfaces;
using App.Interfaces.Notificators;
using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace App.Services;

public class OrderServices
{
    private readonly IOrderStore _orderStore;
    private readonly IOrderStateNotificator _notificator;

    public async Task<Result<Order>> GetById(Guid id)
    {
        var getOrder = await _orderStore.GetById(id);
        return getOrder;
    }
    public async Task<Result<Order>> GetByCode(string code)
    {
        return await _orderStore.GetByCode(code);
    }
    public async Task<Result> ChangeState(Guid orderId, OrderState newState)
    {
        var getOrderResult = await _orderStore.GetById(orderId);

        if (getOrderResult.IsFailure)
        {
            return getOrderResult;
        }

        var order = getOrderResult.Value;

        var updateStateResult = order.ChangeState(newState);

        if (updateStateResult.IsFailure)
        {
            return updateStateResult;
        }

        var saveChangeResult = await _orderStore.SaveChanges(order);

        if (saveChangeResult.IsFailure)
        {
            return saveChangeResult;
        }

        return await _notificator.NotifyChangeOrderState(order);
    }
    
}