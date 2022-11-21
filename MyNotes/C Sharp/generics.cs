//C# generics allow users to define classes and methods with a placeholder type. 
//This provides amazing code re-usability while still retaining type safety. 

List<string> games = new List<string>(); //List is a generic class

games.Add(52526);//error
games.Add("among us");

//----------------------------------------------------------------------------

public class GenericClass1<T> //putting <T> the class becomes generic
{
	public T Data;
}

var myClass = new GenericClass1<string>();

myClass.Data = 98552;//error
myClass.Data = "Wobbly";

//-----------------------------------------------------------------------------

public class GenericClass2<T>
{
	public T Data;

	public GenericClass2(T data) //constructor
	{
		Data = data;
	}
}

var myClass = new GenericClass2<string>(452); //error
var myClass = new GenericClass2<string>("Wobbly");

//------------------------------------------------------------------------------

void Print<T>(T input) // this generic function can take any type
{
	Console.WriteLine(input);
}

Print(420);
Print("My hero");

//-------------------------------------------------------------------------------

public class HeroHelper<T> where T : Hero
{
	public T Data;

	public HeroHelper(T data)
	{
		Data = data;
	}

	public void Print()
	{
		Console.WriteLine(Data);
	}

	public void ForceHeroToAttack()
	{
		Data.Attack();
	}
}

public abstract class Hero
{
	public int Damage;
	public string Name;
	public void Attack()
	{
		Console.WriteLine($"{Name} did {Damage} damage");
	}
}

public class Mage : Hero { }

public class Archer : Hero { }

var mage = new Mage()
{
	Name = "Tarodev",
	Damage = 420
};

var helper = new HeroHelper<Mage>(mage); // accepts only Hero type

helper.Print();

//-----------------------------------------------------------------------------
//exceed previous example to create a factory method

T HeroFactory<T>(string heroName) where T : Hero, new()
{
	T newHero = new T();
	newHero.Name = heroName;
	return newHero;
}

// Archer must be a class with constructor without parameters
// because of new() in HeroFactory
var archer = HeroFactory<Archer>("Legolas");