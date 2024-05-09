using BlazingPizza.Model;
using Humanizer;
using System.ComponentModel;
using System.Configuration;

namespace BlazingPizza.Services
{
    /*
     Create a class that defines the properties you want to store and register it as a scoped service. 
    In any component where you want to set or use the AppState values, you inject the service and then you can access its properties. 
    Unlike component parameters and cascading parameters,values in AppState are available to all components in the application
     */
    //To manage the state of the order.the app shows the configuration dialog and it'll allow you to cancel or move on to ordering the pizza
    public class OrderStateService
    {
        public bool showingConfigureDialog { get; private set; }
        //you can GET the configuringPizza value from outside the class. (because its public) private set means you only can set the value of configuringPizza inside the class.
        public Pizza configuringPizza { get; private set; }
        public Order Order { get; private set; } = new Order();

        public SaleStateService PizzaSaleState { get; private set; }

        public int PizzaOrderedToday { get; set; } = 0;

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
            PizzaOrderedToday++;
        }


    }
}
