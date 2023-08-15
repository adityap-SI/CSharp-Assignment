namespace Shopping_Cart
{
    class Item
    {
        public string Name { get; }
        public double Price { get; }
        public int Quantity { get; }

        public Item(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    class ShoppingCart
    {
        private List<Item> items;

        public ShoppingCart()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void DisplayCartContents()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("The shopping cart is empty.");
                return;
            }

            Console.WriteLine("Shopping Cart Contents:");
            foreach (Item item in items)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
            }
        }

        public double TotalCost
        {
            get
            {
                if (items.Count == 0)
                    return 0;

                double totalCost = items.Sum(item => item.Price * item.Quantity);
                return totalCost;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            ShoppingCart cart = new ShoppingCart();

            while (true)
            {
                Console.WriteLine("Enter 1 to add an item to the cart");
                Console.WriteLine("Enter 2 to display the cart contents");
                Console.WriteLine("Enter 3 to calculate the total cost of the cart");
                Console.WriteLine("Enter 4 to exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the item's name:");
                        string itemName = Console.ReadLine();

                        Console.WriteLine("Enter the item's price:");
                        double itemPrice = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter the item's quantity:");
                        int itemQuantity = Convert.ToInt32(Console.ReadLine());

                        Item newItem = new Item(itemName, itemPrice, itemQuantity);
                        cart.AddItem(newItem);
                        break;

                    case "2":
                        cart.DisplayCartContents();
                        break;

                    case "3":
                        double totalCost = cart.TotalCost;
                        Console.WriteLine($"Total cost of the cart: {totalCost}");
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

}
