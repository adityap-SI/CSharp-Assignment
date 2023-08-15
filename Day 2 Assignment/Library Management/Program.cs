namespace Library_Management
{
    class Book
    {
        public string Title { get; }
        public string Author { get; }
        public string Genre { get; }
        public int QuantityAvailable { get; private set; }

        public Book(string title, string author, string genre, int quantityAvailable)
        {
            Title = title;
            Author = author;
            Genre = genre;
            QuantityAvailable = quantityAvailable;
        }

        public void AddQuantity(int quantity)
        {
            QuantityAvailable += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            if (QuantityAvailable >= quantity)
                QuantityAvailable -= quantity;
        }
    }

    class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DisplayBookList()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("The library has no books.");
                return;
            }

            Console.WriteLine("Library Book List:");
            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Quantity Available: {book.QuantityAvailable}");
            }
        }

        public void SearchByTitle(string title)
        {
            List<Book> foundBooks = books.FindAll(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

            if (foundBooks.Count == 0)
            {
                Console.WriteLine($"No books found with the title: {title}");
            }
            else
            {
                Console.WriteLine($"Books found with the title: {title}");
                foreach (Book book in foundBooks)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Quantity Available: {book.QuantityAvailable}");
                }
            }
        }

        public void SearchByAuthor(string author)
        {
            List<Book> foundBooks = books.FindAll(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase));

            if (foundBooks.Count == 0)
            {
                Console.WriteLine($"No books found with the author: {author}");
            }
            else
            {
                Console.WriteLine($"Books found with the author: {author}");
                foreach (Book book in foundBooks)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, Quantity Available: {book.QuantityAvailable}");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Library library = new Library();

            while (true)
            {
                Console.WriteLine("Enter 1 to add a book");
                Console.WriteLine("Enter 2 to display the book list");
                Console.WriteLine("Enter 3 to search for books by title");
                Console.WriteLine("Enter 4 to search for books by author");
                Console.WriteLine("Enter 5 to exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter the book's title:");
                        string title = Console.ReadLine();

                        Console.WriteLine("Enter the book's author:");
                        string author = Console.ReadLine();

                        Console.WriteLine("Enter the book's genre:");
                        string genre = Console.ReadLine();

                        Console.WriteLine("Enter the quantity of books available:");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        Book newBook = new Book(title, author, genre, quantity);
                        library.AddBook(newBook);
                        break;

                    case "2":
                        library.DisplayBookList();
                        break;

                    case "3":
                        Console.WriteLine("Enter the title to search for:");
                        string titleToSearch = Console.ReadLine();
                        library.SearchByTitle(titleToSearch);
                        break;

                    case "4":
                        Console.WriteLine("Enter the author to search for:");
                        string authorToSearch = Console.ReadLine();
                        library.SearchByAuthor(authorToSearch);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

}
