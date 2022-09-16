
const string inputString = "29535123p487234875976457236459";

List<long> matches = new List<long>();

for (int i = 0; i < inputString.Length; i++)
{
    char currentChar = inputString[i];
    int endIndex = inputString.IndexOf(currentChar, i + 1);
    for (int j = i; j < endIndex; j++)
	{
        string subString = inputString.Substring(i, endIndex - i + 1);
        if (CheckForLetters(subString))
        {
            break;
        }
        else
        {
            matches.Add(long.Parse(subString));
            ColorSubString(i, endIndex);
            break;
        }
    }
}

Console.WriteLine($"\nSum of all matches = {CalculateAll(matches)}");


void ColorSubString(int startIndex, int endIndex)
{
    for (int i = 0; i < inputString.Length; ++i)
    {
        if (i == startIndex)
        {
            Console.Write("\u001B[;91m"); //Coloring text red
        }
        Console.Write(inputString[i]);
        
        if (i == endIndex)
        {
            Console.Write($"\u001B[0m"); //Reseting text color
        }
    }
    Console.WriteLine();
}

bool CheckForLetters(string subString)
{
    for (int i = 0; i < subString.Length; i++)
    {
        if (char.IsLetter(subString[i]))
        {
            return true;
        }
    }
    return false;
}
long CalculateAll(List<long> matches)
{
    long totalAmount = 0;
    foreach (var numbers in matches)
    {
        totalAmount += numbers;
    }
    return totalAmount;
}