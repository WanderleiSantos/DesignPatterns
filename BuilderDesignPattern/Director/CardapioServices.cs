using BuilderDesignPattern.Builders.Base;
using BuilderDesignPattern.Domain;
using BuilderDesignPattern.Domain.Enums;

namespace BuilderDesignPattern.Director
{
    public class CardapioServices
    {
        public void PreparaPizzaSemBorda(IPizzaBuilder pizzaBuilder, PizzaSize pizzaSize)
        {
            pizzaBuilder.PreparaMassa(pizzaSize);
            pizzaBuilder.InsereIngredientes();
            pizzaBuilder.TempoForno();
            pizzaBuilder.DefineValor();
        }

        public void PreparaPizzaComBorda(IPizzaBuilder pizzaBuilder, PizzaSize pizzaSize, Borda borda)
        {
            pizzaBuilder.PreparaMassa(pizzaSize);
            pizzaBuilder.PreparaBorda(borda);
            pizzaBuilder.InsereIngredientes();
            pizzaBuilder.TempoForno();
            pizzaBuilder.DefineValor();
        }
    }
}