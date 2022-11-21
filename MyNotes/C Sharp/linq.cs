using System;
using System.Linq;

class Program
{
	static void Main()
	{
		Library library = new Library
			{
				new Book { Title = "Dr No", Author = "Ian Fleming" },
				new Book { Title = "Emma", Author = "Jane Austen" },
				new Book { Title = "Goldfinger", Author = "Ian Fleming" },
				new Book { Title = "Pride and Prejudice", Author = "Jane Austen" }
			};

		// For using Linq the Library class must implements IEnumerable<T>

		foreach (var b in library.Skip(1).Take(2).Reverse())
			Console.WriteLine(b.Title);
		// prints:
		// Goldfinger
		// Emma

		foreach (var b in library.Where(b => b.Author.EndsWith("Fleming")))
			Console.WriteLine(b);
		// prints:
		// Dr No (Ian Fleming)
		// Goldfinger (Ian Fleming)

		Console.WriteLine(library.Max(b => b.Title));
		// prints:
		// Pride and Prejudice
	}
}