static void Main(string[] args) {
    WithHomemadeGeneric();
}

public abstract class Fruit {
    public string Name { get; set; }
}

public class Apple : Fruit { }

public class Banana : Fruit { }

public class Bag<T> : IBag<T> {
    private List<T> _items = new List<T> ();
    public T Get(int idx) => _items[idx];
    public void Add(T f) => _items.Add(f);
}

public class BagOfFruit {
    private List<Fruit> _items = new List<Fruit>();
    public virtual Fruit Get(int idx) => _items[idx];
    public virtual void Add(Fruit f) => _items.Add(f);
}

public class BagOfApples : BagOfFruit {
    public new Apple Get(int idx) => (Apple)base.Get(idx);
    public void Add(Apple a) => base.Add(a);
}

public interface IBag<out T> {
    T Get(int idx);
}

private static void WithHomemadeGeneric() {
    Bag<Apple> bagOfApples = new Bag<Apple>();

    bagOfApples.Add(new Apple { Name = "Granny Smith" });
    bagOfApples.Add(new Apple { Name = "Cox's Orange Pippin" });
    bagOfApples.Add(new Apple { Name = "Golden Delicious" });

    IBag<Fruit> bagOfFruit = bagOfApples;

    Console.WriteLine(bagOfFruit.Get(0).Name);
    Console.WriteLine(bagOfFruit.Get(1).Name);

    //bagOfApples.Add(new Banana { Name = "Blue Java" });
    //bagOfFruit.Add(new Banana { Name = "Blue Java" });
}