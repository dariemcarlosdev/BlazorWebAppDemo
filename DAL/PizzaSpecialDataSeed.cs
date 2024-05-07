using BlazingPizza.Model;

namespace BlazingPizza.DAL
{
    public static class PizzaSpecialDataSeed
    {
        public static void OnInitialize(PizzaStoreDemoContext context)
        {
            var specials = new List<PizzaSpecial>
            {
                new()
                {
                Name = "Basic Cheese Pizza",
                Description = "It's cheesy and delicious. Why wouldn't you want one?",
                BasePrice = 9.99m,
                ImageUrl = "img/pizzas/cheese.jpg",
                },
                new()
                {
                Id = 2,
                Name = "The Baconatorizor",
                Description = "It has EVERY kind of bacon",
                BasePrice = 11.99m,
                ImageUrl = "img/pizzas/bacon.jpg",
                },
                new()
                {
                Id = 3,
                Name = "Classic pepperoni",
                Description = "It's the pizza you grew up with, but Blazing hot!",
                BasePrice = 10.50m,
                ImageUrl = "img/pizzas/pepperoni.jpg",
                }
            };

            context.Specials.AddRange(specials);
            context.SaveChangesAsync();
        }
    }
}
