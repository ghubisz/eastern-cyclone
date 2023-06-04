using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book (string title, string author)
        {
            Title = title;
            Author = author;
            IsAvailable = true;
        }
    }

    class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public void AddBook(string title, string author)
        {
            books.Add(new Book(title, author));
            Console.WriteLine("Book added successfully!");
        }
        
        public void SearchBook(string title)
        {
            bool found = false;
            foreach (var book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Book Found: {book.Title} by {book.Author}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Book not found!");
            }
        }

        public void CheckOutBook(string title)
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    if (book.IsAvailable)
                    {
                        book.IsAvailable = false;
                        Console.WriteLine("Book checked out successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Book is not available for checkout!");
                    }
                    return;
                }
            }

            Console.WriteLine("Book not found!");
        }

        public void ReturnBook(string title)
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    book.IsAvailable = true;
                    Console.WriteLine("Book returned successfully!");
                    return;
                }
            }

            Console.WriteLine("Book not found!");
        }
    }

    class Python
    {
        static void Main(string [] args)
        {
            Library library = new Library();

            while (true)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search Book");
                Console.WriteLine("3. Check Out Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Book Author: ");
                        string author = Console.ReadLine();
                        library.AddBook(title, author);
                        break;
                    case 2:
                        Console.Write("Enter Book Title to search: ");
                        string searchTitle = Console.ReadLine();
                        library.SearchBook(searchTitle);
                        break;
                    case 3:
                        Console.Write("Enter Book Title to check out: ");
                        string checkoutTitle = Console.ReadLine();
                        library.CheckOutBook(checkoutTitle);
                        break;
                    case 4:
                        Console.Write("Enter Book Title to return: ");
                        string returnTitle = Console.ReadLine();
                        library.ReturnBook(returnTitle);
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }
    }
}