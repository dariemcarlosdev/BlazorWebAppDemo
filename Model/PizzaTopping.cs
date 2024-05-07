namespace BlazingPizza.Model
{
    public class PizzaTopping
    {
        public int Id { get; set; }

        public string Ingredients { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string GetFormattedPrice() => Price.ToString("0.00");
    }

}
