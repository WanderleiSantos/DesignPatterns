using BuilderDesignPattern.Domain;
using BuilderDesignPattern.Domain.Enums;

namespace BuilderDesignPattern.Builders.Base
{
    public interface IPizzaBuilder
    {
        void PreparaBorda(Borda borda);
        void PreparaMassa(PizzaSize pizzaSize);
        void InsereIngredientes();
        void DefineValor();
        void TempoForno();
        Pizza GetPizza();
    }
}