
interface GreetingsRus
{
    string Hello();
}

interface GreetingsEng
{
    string Hello();
}

abstract class GreetingsFr {
    public abstract string Hello();
}

class MyGreetings : GreetingsFr, GreetingsEng, GreetingsRus
{
    public override string Hello()
    {
        return "Salut!";
    }

    string GreetingsRus.Hello() {
        return "Привет!";
    }

    string GreetingsEng.Hello() {
        return "Hi!";
    }
}


internal class Program {
    public static void Main(string[] args) {
        var myGreetings = new MyGreetings();
        Console.WriteLine(myGreetings.Hello());
        Console.WriteLine(((GreetingsRus)myGreetings).Hello());
        Console.WriteLine(((GreetingsEng)myGreetings).Hello());

    }
}
