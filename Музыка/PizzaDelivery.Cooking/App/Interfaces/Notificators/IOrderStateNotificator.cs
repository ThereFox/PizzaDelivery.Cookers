using CSharpFunctionalExtensions;
using PizzaDelivery.Cooking.Domain.Entitys;

namespace App.Interfaces.Notificators;

public interface IOrderStateNotificator
{
    public Result StartCookOrder(Order order);
    public Result OrderCooked(Order order);
}