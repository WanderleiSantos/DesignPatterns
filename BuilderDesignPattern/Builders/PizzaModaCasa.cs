using BuilderDesignPattern.Builders.Base;
using BuilderDesignPattern.Domain;
using BuilderDesignPattern.Domain.Enums;
using BuilderDesignPattern.Processors;

namespace BuilderDesignPattern.Builders
{
    public class PizzaModaCasa : PizzaBuilderBase, IPizzaBuilder
    {
        public PizzaModaCasa(ICalculaValor calculaValor) : base(calculaValor)
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
            this.Pizza.Sabor = "Moda da Casa";
            this.Pizza.IngredientesType =
                IngredientesType.Alho |
                IngredientesType.Calabresa |
                IngredientesType.Cebola |
                IngredientesType.Mussarela |
                IngredientesType.Provolone |
                IngredientesType.Pimentao |
                IngredientesType.Majericao |
                IngredientesType.Cheddar |
                IngredientesType.Catupiry;
        }

        public void TempoForno()
        {
            this.Pizza.TempoFornoMin = 28;
        }
    }
}