Console.WriteLine("Hello, World!");

var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

// strings - pomocí LINQu vytvořte nové pole kde jsou všechna slova uppercase

var result = strings.Select(x => x.ToUpper());

PrintList(result.ToList());



static void PrintList(List<string> listToPrint)
{
    foreach (var item in listToPrint)
    {
        Console.WriteLine(item);
    }
}