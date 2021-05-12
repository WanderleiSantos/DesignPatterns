using System;
using System.Linq;
using BuilderDesignPattern.Domain;
using BuilderDesignPattern.Domain.Enums;

namespace BuilderDesignPattern.Processors
{
    public class CalculaValor  : ICalculaValor
    {
        public void DefineValor(Pizza pizza)
        {
            var totalIngradientes = Enum.GetValues(typeof(IngredientesType)).Cast<Enum>().Count(pizza.IngredientesType.HasFlag);

            var valorIngredintes = totalIngradientes * 1.70;
            var valorTamanho = (int)pizza.PizzaSize * 10;
            var valorTipo = pizza.PizzaType == PizzaType.Doce ? 10 : 0;

            var valorBorda = 0;

            if (pizza.Borda != null)
            {
                valorBorda = pizza.Borda.BordaType == BordaType.Chocolate
                    ? (5 * (int)pizza.Borda.BordaSize)
                    : (2 * (int)pizza.Borda.BordaSize);
            }

            pizza.Valor = valorIngredintes + valorTamanho + valorTipo + valorBorda;
        }
    }
}