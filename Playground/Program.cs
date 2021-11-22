using Playground;

Console.WriteLine("Hello, World!");

var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var strings = new[] { "zero", "one", "two", "three", 
                        "four", "five", "six", "seven",
                        "eight", "nine" };

// 1 strings - pomocí LINQu vytvořte nové pole kde jsou všechna slova uppercase
//var result = strings.Select(x => x.ToUpper());

// 2 numbers - zjiste pomoci LINQu jestli pole obsahuje pouze suda cisla
//bool isOnlyEvenNumbers = numbers.All(x => x % 2 == 0);
//global::System.Console.WriteLine($"jsou vsechna cisla suda: {isOnlyEvenNumbers}");

// 3 - vypište čísla v poli numbers jako slova - LINQ
// var result = numbers.Select(x => strings[x]);

// 4 - zjistěte kolik obsahují všechna
// slova v poli "strings" dohromady písmen - LINQ
// var sumletters = strings.Select(x => x.Length).Sum();
// Console.WriteLine($"vsechna slova v poli strings maji dohromady {sumletters} pismen");

// 5 - vytvořte novou kolekci obsahující dvojici
// lowercase i uppercase variantu
//var result = strings
//            .Select(slovo => new UpperLowerString(slovo))
//            .Select(x => $"upper:{x.UpperCase} lower:{x.LowerCase}");

// - 5 pomoci tuplu
var result = strings.Select(slovo => (slovo.ToLower(), slovo.ToUpper()));


//PrintList(result.ToList());

PrintItems<(string, string)>(result);

static void PrintList(List<string> listToPrint)
{
    foreach (var item in listToPrint)
    {
        Console.WriteLine(item);
    }
}

static void PrintItems<T>(IEnumerable<T> items)
{
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}