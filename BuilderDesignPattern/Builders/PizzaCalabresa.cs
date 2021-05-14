using BuilderDesignPattern.Builders.Base;
using BuilderDesignPattern.Domain;
using BuilderDesignPattern.Domain.Enums;
using BuilderDesignPattern.Processors;

namespace BuilderDesignPattern.Builders
{
    public class PizzaCalabresa : PizzaBuilderBase, IPizzaBuilder
    {
        public PizzaCalabresa(ICalculaValor calculaValor) : base(calculaValor)
        {
        }

        public void PreparaBorda(Borda borda)
        {
            this.Pizza.Borda = borda;
        }

        public void PreparaMassa(PizzaSize pizzaSize)
        {
            this.Init();
            this.Pizza.PizzaType = PizzaType.Salgada;
            this.Pizza.PizzaSize = pizzaSize;
        }

        public void InsereIngredientes()
        {
            this.Pizza.Sabor = "Calabresa";
            this.Pizza.IngredientesType = IngredientesType.Calabresa | IngredientesType.Azeitona |
                                          IngredientesType.Cebola | IngredientesType.Cheddar;
        }

        public void TempoForno()
        {
            this.Pizza.TempoFornoMin = 20;
        }
    }
}