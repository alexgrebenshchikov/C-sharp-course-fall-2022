// See https://aka.ms/new-console-template for more information
using hw16.Task1;
using hw16.Task2;
using hw16.Task3;

void RunZeroEvenOdd(int n)
{
    var zeroEvenOdd = new ZeroEvenOdd(n);
    var threads = new List<Thread>
    {
        new(() => zeroEvenOdd.Zero(Console.Write)),
        new(() => zeroEvenOdd.Even(Console.Write)),
        new(() => zeroEvenOdd.Odd(Console.Write))
    };
    threads.ForEach(t => t.Start());
    threads.ForEach(t => t.Join());
    Console.WriteLine();
}



void Task1()
{
    RunZeroEvenOdd(2);
    RunZeroEvenOdd(5);
}

void Task2()
{
    var array = new List<int> { 3, 1, 4, 1, 5, 9 , 2, 6, 5 };
    var parallelArray = new ParallelArray(array);

    var threads = new List<Thread>
    {
        new(() => parallelArray.ThreadAverage()),
        new(() => parallelArray.ThreadAverage()),
        new(() => parallelArray.ThreadMin()),
        new(() => parallelArray.ThreadSwap()),
        new(() => parallelArray.ThreadSort()),
    };
    threads.ForEach(t => t.Start());

    Thread.Sleep(500);
    parallelArray.Terminate();
    threads.ForEach(t => t.Join());
}

void Task3()
{
    var controller = new H2OController();
    controller.MakeH2O("HHO");
    controller.MakeH2O("HHOHOH");
    controller.MakeH2O("HHHOOOHHH");
}

//Task1();
//Task2();
//Task3();
