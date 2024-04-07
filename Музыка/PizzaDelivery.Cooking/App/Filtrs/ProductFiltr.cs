using PizzaDelivery.Cooking.Domain.Entitys;
using PizzaDelivery.Cooking.Domain.ValueObject;

namespace PizzaDelivery.Cooking.Domain.Filtrs;

public record ProductFiltr
(
    List<Guid> Creaters,
    List<ProductCookState> State
);