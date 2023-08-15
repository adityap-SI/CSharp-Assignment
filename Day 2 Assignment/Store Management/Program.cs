namespace Store_Management
{
    class Product
    {
        public string Name { get; }
        public double Price { get; }
        public int QuantityInStock { get; private set; }
        public string Category { get; }

        public Product(string name, double price, int quantityInStock, string category)
        {
            Name = name;
            Price = price;
            QuantityInStock = quantityInStock;
            Category = category;
        }

        public void AddQuantity(int quantity)
        {
            QuantityInStock += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            if (QuantityInStock >= quantity)
                QuantityInStock -= quantity;
        }
    }

    class Store
    {
        private List<Product> products;

        public Store()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DisplayProductList()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("The store has no products.");
                return;
            }

            Console.WriteLine("Product List:");
            foreach (Product product in products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: ${product.Price}, Quantity in Stock: {product.QuantityInStock}, Category: {product.Category}");
            }
        }

        public double CalculateTotalValueInStock()
        {
            double totalValue = 0;

            foreach (Product product in products)
            {
                totalValue += product.Price * product.QuantityInStock;
            }

            return totalValue;
        }
    }

    class Program
    {
        static void Main()
        {
            Store store = new Store();

            while (true)
            {
                Console.WriteLine("Enter 1 to add a product");
                Console.WriteLine("Enter 2 to display the product list");
                Console.WriteLine("Enter 3 to calculate the total value of products in stock");
                Console.WriteLine("Enter 4 to exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the product's name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter the product's price:");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Enter the quantity of products in stock:");
                        int quantityInStock = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter the product's category:");
                        string category = Console.ReadLine();

                        Product newProduct = new Product(name, price, quantityInStock, category);
                        store.AddProduct(newProduct);
                        break;

                    case "2":
                        store.DisplayProductList();
                        break;

                    case "3":
                        double totalValueInStock = store.CalculateTotalValueInStock();
                        Console.WriteLine($"Total value of products in stock: ${totalValueInStock}");
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
