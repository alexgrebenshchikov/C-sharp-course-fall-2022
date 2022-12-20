// See https://aka.ms/new-console-template for more information
using hw15.Task1;
using hw15.Task3;
using hw15.Task4;

void Task1() {
    var bb = new BearAndBees();
    bb.Simulate(5, 5);
}

void Task3() {
    // 5th client won't be served
    var barber = new Barber(3);
    barber.AddClient(new Client("Alice"));
    barber.AddClient(new Client("Bob"));
    barber.AddClient(new Client("Carol"));
    barber.AddClient(new Client("Derek"));
    barber.AddClient(new Client("Evan"));
    barber.EndWork();
    // All clients will be served
    Console.WriteLine("########################");
    barber = new Barber(3);
    barber.AddClient(new Client("Alice"));
    barber.AddClient(new Client("Bob"));
    barber.AddClient(new Client("Carol"));
    Thread.Sleep(1000);
    barber.AddClient(new Client("Derek"));
    barber.EndWork();

}

void Task4() {
    var input = new List<int> { 3, 7, 7, 1, -23, 12, 10 };
    var sorted = new ParallellMergeSort().MergeSort(input, 4);
    Console.WriteLine(String.Join(" ",sorted));
}

//Task1();
//Task3();
//Task4();