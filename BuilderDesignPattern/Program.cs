using System;
using BuilderDesignPattern.Builders;
using BuilderDesignPattern.Builders.Base;
using BuilderDesignPattern.Director;
using BuilderDesignPattern.Domain;
using BuilderDesignPattern.Domain.Enums;
using BuilderDesignPattern.Processors;

namespace BuilderDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var calcValor = new CalculaValor();
            IPizzaBuilder pizzaCalabresaBuilder = new PizzaCalabresa(calcValor);
            var cardapioService = new CardapioServices();
            
            cardapioService.PreparaPizzaComBorda(pizzaCalabresaBuilder, PizzaSize.Grande, new Borda
            {
                BordaType = BordaType.Catupiry, BordaSize = BordaSize.Gossa
            });

            var pizzaCalabresa = pizzaCalabresaBuilder.GetPizza();
            
            View("Pizza 1: ", pizzaCalabresa);
        }
        
        public static void View(string msg, Pizza pizza)
        {
            Console.WriteLine($"{pizza.Sabor} / {pizza.Valor:C} / {pizza.TempoFornoMin} min / {pizza.PizzaSize.ToString()}");
        }
    }
}