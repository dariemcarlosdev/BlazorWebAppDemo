using BlazingPizza.Model;
using Humanizer;
using System.ComponentModel;
using System.Configuration;

namespace BlazingPizza.Services
{
    //To manage the state of the order.the app shows the configuration dialog and it'll allow you to cancel or move on to ordering the pizza
    public class PizzaOrderState
    {
        public bool showingConfigureDialog { get; private set; }
        //you can GET the configuringPizza value from outside the class. (because its public) private set means you only can set the value of configuringPizza inside the class.
        public Pizza configuringPizza { get; private set; }
        public Order Order { get; private set; } = new Order();

        // to create a pizza
        // When a customer selects a pizza, the server executes the ShowConfigurePizzaDialog method that creates a pizza with the special pizza data and sets the showingConfigureDialog variable to true.
        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            configuringPizza = new()
            {
                Special = special,
                SpecialId = special.Id,
                Size = Pizza.DefaultSize,
                Topping = new List<PizzaTopping>()

            };

            showingConfigureDialog = true;
        }
        public void CancelConfigurePizzaDialog()
        {
                configuringPizza = null;
                showingConfigureDialog = false;
        }

        public void ConfirmConfigurePizzaDialog()
        {
            Order.Pizzas.Add(configuringPizza);
            configuringPizza = null;
            showingConfigureDialog = false;
        }
    }
}
