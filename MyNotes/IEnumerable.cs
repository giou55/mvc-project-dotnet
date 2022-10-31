List<int> ints = new List<int> { 3, 56, 78, 21, 34, 98, 45, 22 };

//iteration with foreach loop works because List implements IEnumerable<T>

// first way to iterate
IEnumerator<int> i = ints.GetEnumerator();

while (i.MoveNext())
	Console.WriteLine(i.Current);

// second way to iterate
foreach (int i in ints)
	Console.WriteLine(i);

// third way to iterate
using (IEnumerator<int> i = ints.GetEnumerator())
{
	while (i.MoveNext())
		Console.WriteLine(i.Current);
}


// Implementing IEnumerable for Library ------------------------------------------------ 
public class Library : IEnumerable<Book>
{
	private List<Book> _books = new List<Book>();

	public void Add(Book book)
	{
		_books.Add(book);
	}

	public IEnumerator<Book> GetEnumerator()
	{
		return new BookEnumerator(this);
		// return _books.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public Book this[int idx] => _books[idx];
	public int Count => _books.Count;
}

public class BookEnumerator : IEnumerator<Book>
{
	private Library _library;
	private int _idx;

	public BookEnumerator(Library library)
	{
		_library = library;
		_idx = -1;
	}

	public Book Current => _library[_idx];

	object IEnumerator.Current => Current;

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		return ++_idx < _library.Count;
	}

	public void Reset()
	{
		_idx = -1;
	}
}

static void Main()
{
	Library library = new Library
			{
				new Book { Title = "Dr No", Author = "Ian Fleming" },
				new Book { Title = "Emma", Author = "Jane Austen" },
				new Book { Title = "Goldfinger", Author = "Ian Fleming" },
				new Book { Title = "Pride and Prejudice", Author = "Jane Austen" }
			};

	// now foreach loop works because Library implements IEnumerable<T>
	foreach (var b in library)
		Console.WriteLine(b);

	Console.WriteLine(library.Max(b => b.Title));
}