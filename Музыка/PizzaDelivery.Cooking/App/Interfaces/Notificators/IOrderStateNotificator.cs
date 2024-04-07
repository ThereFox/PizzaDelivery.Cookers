using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces.Notificators;

public interface IOrderStateNotificator
{
    public Task<Result> NotifyChangeOrderState(Order order);
}