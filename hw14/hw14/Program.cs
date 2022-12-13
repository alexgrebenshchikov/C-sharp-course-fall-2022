// See https://aka.ms/new-console-template for more information
using hw14.Task1;
using hw14.Task2;
using hw14.Task3;

void Task1() {
    var res = new Race().Run();
    Console.WriteLine(res);
}

void Task2() {
    for (int i = 0; i < 10; i++) {
        new SequentialPrinter().Run();
    }
}

void Task3() {
    Sleepsort.Sort(new List<string> { "aaaa", "aa", "a", "aaa", "aaa", "aaaaaa" });
    Console.WriteLine();
    Sleepsort.Sort2(new List<string> { "aaaa", "aa", "a", "aaa", "aaa", "aaaaaa"});
}

//Task1();
//Task2();
Task3();