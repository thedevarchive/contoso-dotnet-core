using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    //Indicates the next ID to assign to the next Pizza added to the list
    static int nextId = 3;
    static PizzaService()
    {
        //Initialise Pizzas
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Pizza> GetAll() => Pizzas;

    //gets the first Pizza object with that ID 
    //Each ID should be unique so there should be only one result
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    //Adds the Pizza argument to this class's List of Pizzas
    //Also increases nextId by 1
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    //Find Pizza to delete
    //If found, remove it from Pizzas list
    //Otherwise, do nothing
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    //Takes in one Pizza argument (with the changes to an existing Pizza)
    //Compares the ID it has to the list of Pizzas 
    //If a Pizza on that list matches the argument's ID
    //Get its index and assign the argument to the element in the Pizza list
    //In that way, the previous information stored on the list 
    //will be deleted and replaced with the modified one
    //stored in the Pizza argument
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
}