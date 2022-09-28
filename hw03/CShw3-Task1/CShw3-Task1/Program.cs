var x = new
{
    Items = new List<int> { 1, 2, 3 }.GetEnumerator()
};
while (x.Items.MoveNext())
    Console.WriteLine(x.Items.Current);

/* 
    x.Items - readOnly поле, поэтому при попытке его поменять при вызове x.Items.MoveNext() происходит копирование, и поле на самом деле не меняется.
    Согласно документации Enumerator изначально указывает логически на элемент перед первым элементом List, поэтому при запуске кода мы видим бесконечный
    вывод нулей (0 - дефолтное значение для типа Int)
 
 */
