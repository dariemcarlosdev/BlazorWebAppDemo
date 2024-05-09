namespace BlazingPizza.Services
{
    /*
     Create a class that defines the properties you want to store and register it as a scoped service. 
    In any component where you want to set or use the AppState values, you inject the service and then you can access its properties. 
    Unlike component parameters and cascading parameters,values in AppState are available to all components in the application
     */
    public class SaleStateService
    {
        public int PizzaSoldToday { get; set; }
    }
}
