using System.Collections.Immutable;
using System.Xml;

int GetInt32(string input)
{
    int result = 0;
    while (true)
    {
        Console.Write("zadej číslo" + input + ": ");
        try
        {
            result = Convert.ToInt32(Console.ReadLine());
            break;
        }
        catch
        {
            Console.WriteLine("musíš zadat celé číslo");
        }
    }
    return result;
}

bool isAllPositiv(int[] input)
{
    foreach (int i in input)
    {
        if (i < 0) return false;
    }
    return true;
}

int lenght(int[] input)
{
    return input.Count();
}


int max(int[] input)
{
    int output = 0;
    foreach (int i in input)
    {
        if (i > output) output = i;
    }
    return output;
}


int min(int[] input)
{
    int output = input[0];
    foreach (int i in input)
    {
        if (i < output) output = i;
    }
    return output;
}


int sum(int[] input)
{
    int output = 0;
    foreach (int i in input)
    {
        output += i;
    }
    return output;
}


int product(int[] input)
{
    int output = 1;
    foreach (int i in input)
    {
        output *= i;
    }
    return output;
}


double aritmeticAverage(int[] input)
{
    int localsum = sum(input);
    int locallenght = lenght(input);
    return (float)localsum / (float)locallenght;
}


double geometricAverage(int[] input)
{
    if (isAllPositiv(input))
    {
        int localprodact = product(input);
        int locallenght = lenght(input);
        return Math.Pow(localprodact, 1d / locallenght);
    }
    else return -1;


}

int[] countForEach(int[] input)
{
    Array.Sort(input);
    int[] output = new int[max(input)];
    int number = input[0];
    int currentSum = 0;
    foreach (int i in input)
    {
        if (i == number) currentSum++;
        else
        {
            output[number] = currentSum;
            int rozdil = input[i + 1] - number;
            for (int j = 0; j < rozdil; j++)
            {
                output[number + rozdil] = 0;
            }
            currentSum = 0;
            number = input[i + 1];
        }
    }
    return output;
}


int[] list = { 1, 2, 5, 5, 5, 5, 8, 9, 4, 54 };
while (true)
{
    Console.ForegroundColor = ConsoleColor.Gray;
    bool exit = false;
    Console.WriteLine("výběr podprogramů ");
    int choice = GetInt32("");
    switch (choice)
    {
        case 1:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(lenght(list));
            break;

        case 2:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(max(list));
            break;

        case 3:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(min(list));
            break;

        case 4:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(sum(list));
            break;

        case 5:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(product(list));
            break;

        case 6:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(aritmeticAverage(list));
            break;

        case 7:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(geometricAverage(list));
            break;

        case 8:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(countForEach(list));
            break;

        case 9:
            break;

        case 10:
            break;

        case 0:
            exit = true;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("špatné číslo");
            break;
    }
    if (exit) break;
}