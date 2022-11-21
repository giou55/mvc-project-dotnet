public class CSVGenerator<T>
{
	private IEnumerable<T> _data;
	private string _filename;
	private Type _type;

	public CSVGenerator(IEnumerable<T> data, string filename)
	{
		_data = data;
		_filename = filename;

		_type = typeof(T);
	}

	public void Generate()
	{
		var rows = new List<string>();

		rows.Add(CreateHeader());

		foreach (var item in _data)
			rows.Add(CreateRow(item));

		File.WriteAllLines($"{_filename}.csv", rows, Encoding.UTF8);
	}

	private string CreateHeader()
	{
		var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

		var bob = new StringBuilder();

		foreach (var prop in properties)
		{
			bob.Append(prop.Name).Append(",");
		}

		return bob.ToString()[..^1];
	}

	private string CreateRow(T item)
	{
		var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

		var bob = new StringBuilder();

		foreach (var prop in properties)
		{
			bob.Append(CreateItem((dynamic)prop.GetValue(item))).Append(",");
		}

		return bob.ToString()[..^1];
	}

	private string CreateItem(object item) => item.ToString();
	private string CreateItem(DateTime item) => item.ToShortDateString();
}


public enum Rating { Rubbish, Poor, Average, Good, Excellent }

public class Book
{
	public string Author { get; set; }
	public string Title { get; set; }
	public DateTime DateOfPublication { get; set; }
	public Rating Rating { get; set; }
}

public static class BookData
{
	public static IEnumerable<Book> Books = new Book[]
	{
		   new () {Title  = "Goldfinger", Author="Ian Fleming", DateOfPublication = new DateTime(1959, 3, 23), Rating = Rating.Excellent},
		   new () {Title  = "Dr No", Author="Ian Fleming", DateOfPublication = new DateTime(1958, 3, 31), Rating = Rating.Good},
		   new () {Title  = "Live and Let Die", Author="Ian Fleming", DateOfPublication = new DateTime(1954, 4, 5), Rating = Rating.Average},
		   new () {Title  = "Emma", Author="Jane Austen", DateOfPublication = new DateTime(1815, 12, 23), Rating = Rating.Good},
		   new () {Title  = "Persuasion", Author="Jane Austen", DateOfPublication = new DateTime(1818, 1, 1), Rating = Rating.Excellent},
		   new () {Title  = "Great Expectations", Author="Charles Dickens", DateOfPublication = new DateTime(1861, 1, 1), Rating = Rating.Excellent},
		   new () {Title  = "Oliver Twist", Author="Charles Dickens", DateOfPublication = new DateTime(1838, 1, 1), Rating = Rating.Average}
	};
}

public class Weather
{
	public string City { get; set; }
	public string Description { get; set; }
	public double TemperatureCentrigrade { get; set; }
	public double RainfallInches { get; set; }
}

public static class WeatherData
{
	public static IEnumerable<Weather> Weather = new Weather[]
	{
			new () { City = "London", Description = "Sunny spells", TemperatureCentrigrade = 19, RainfallInches = 0 },
			new () { City = "Paris", Description = "Very hot", TemperatureCentrigrade = 27, RainfallInches = 0 },
			new () { City = "New York", Description = "Heavy rain", TemperatureCentrigrade = 8, RainfallInches = 6.598 },
			new () { City = "Munich", Description = "Foggy", TemperatureCentrigrade = 12, RainfallInches = 2.134 },
			new () { City = "Istanbul", Description = "Sunshine and showers", TemperatureCentrigrade = 22, RainfallInches = 8.5 },
			new () { City = "Santiago", Description = "Strong winds", TemperatureCentrigrade = 15, RainfallInches = 0.125 },
	};
}


static void Main()
{
	new CSVGenerator<Book>(BookData.Books, "Books").Generate();
	new CSVGenerator<Weather>(WeatherData.Weather, "Weather").Generate();
}