using System.Text.RegularExpressions;
using static System.Linq.Enumerable;

namespace salt_rat;

public class edabit
{ 
    // 1 https://edabit.com/challenge/NYa5fkHAukJmuhn3W
    public static int SunLoungers(string beach) 
        => string.Format("0{0}0", beach).Split('1').Sum(s => (s.Length - 1) / 2);
    
    // 2 https://edabit.com/challenge/8tyXtHqAT3LAuHMqu
    public static bool IsValidHexCode(string str) 
        => Regex.Match(str, "^#[0-9a-fA-F]{6}$").Success;
    
    // 3 https://edabit.com/challenge/F6m5ZRyzK5fmqTrBG
    public static int collatz(int num) 
        => 
            num < 2 
                ? 0 
                : collatz(num % 2 < 1 ? num / 2 : 3 * num + 1) + 1;
    
    // 4 https://edabit.com/challenge/JYEufqRvkusjr5R58
    public static string Bomb(string txt) 
        => txt.ToLower().Contains("bomb") ? "Duck!!!" : "There is no bomb, relax.";
    
    // 5 https://edabit.com/challenge/2QvnWexKoLfcJkSsc
    public static int[] ArrayOfMultiples(int num, int length) => 
        Range(1, length).Select(x => x * num).ToArray();
    
    // 6 https://edabit.com/challenge/FKb8JY75nkaHz7B3F
    public static int NextPrime(int n) 
        => Math.Pow(2, n) % n == 2 ? n : NextPrime(n + 1);
    
    // 7 https://edabit.com/challenge/xfRucdwGksiyjZq4K
    public static int Sum(int a, int b) => a + b;
    
    // 8 https://edabit.com/challenge/ErLPB5BcrE7yhHhKN
    public static bool ReturnTrue() => true;

    // 9 https://edabit.com/challenge/wrxoYop5uZKG4nNSb
    public static List<int[]> ThreeSum(int[] arr)
    {
        switch (arr.Length)
        {
            case < 3:
                return new List<int[]>();
            case 3 when arr.Sum() == 0:
                return new List<int[]> {arr};
        }

        List<int[]> list = new List<int[]>();
        for (int i = 0; i < arr.Length - 2; i++)
        for (int j = i + 1; j < arr.Length - 1; j++)
        for (int k = j + 1; k < arr.Length; k++)
            if (arr[i] + arr[j] + arr[k] == 0)
                list.Add(new int[] {arr[i], arr[j], arr[k]});
        return list.GroupBy(c
            => string.Join(",", c)).Select(c => c.First().ToArray()).ToList();
    }
    
    // 10 https://edabit.com/challenge/etT7orqDDXJF2zGYM
    public static bool ValidatePassword(string password) =>
        Regex.IsMatch(password,
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?!.*(\S)\1)(?!.*è).{6,24}$");

    // 11 https://edabit.com/challenge/8n43m5c64BKfGCWr3
    public static string NicoCipher(string message, string key)
    {
        List<int> keyNumbers = key.Select(x => key.OrderBy(y => y).ToList().IndexOf(x) + 1).ToList();
        List<Tuple<int, int, char>> output = new List<Tuple<int, int, char>>();
        for (int i = 0; i < message.Length; i++)
        {
            int keyNum = keyNumbers[i % key.Length];
            int row = i / key.Length;
            output.Add(new Tuple<int, int, char>(row, keyNum, message[i]));
        }

        int lastRow = output.Max(y => y.Item1);
        while (output.Where(x => x.Item1 == lastRow).ToList().Count < keyNumbers.Count)
            output.Add(new Tuple<int, int, char>(lastRow, keyNumbers[output.Count % key.Length], ' '));
        List<Tuple<int, int, char>> orderedOutput = output.OrderBy(x => x.Item1).ThenBy(x => x.Item2).ToList();
        return string.Join("", orderedOutput.Select(x => x.Item3));
    }
    
    // 12 https://edabit.com/challenge/8JegGd37XazwMJvs6
    public static string FiboWord(int n)
    {
        if (n < 2) return "invalid";

        string a = "b";
        string b = "a";
        string output = $"{a}";
        for (int i = 1; i < n; i++)
        {
            if(i % 2 == 1)
            {
                output += $", {b}";
                a = b+a;
            }
            else
            {
                output += $", {a}";
                b = a+b;
            }
               
        }
        return output;
    }
    
    // 13 https://edabit.com/challenge/FXt7yKLgFi7SW6JBa
    public static double UniqueFract() 
        => Range(1, 9)
            .SelectMany (numerator 
                => Range(1 + numerator, 9 - numerator)
                .Select(denominator 
                    => (double)numerator/denominator))
            .Distinct()
            .Sum();
    
    // 14 https://edabit.com/challenge/pcHzxfGheeNE4JDpR
    public static bool ValidName(string name) =>
        Regex.IsMatch(name, "^([A-Z]{1}.) ([A-Z]{1}[a-z]{2,})$")
        || Regex.IsMatch(name, "^([A-Z]{1}.) ([A-Z]{1}.) ([A-Z]{1}[a-z]{2,})$")
        || Regex.IsMatch(name, "^([A-Z]{1}[a-z]{1,}) ([A-Z].) ([A-Z]{1}[a-z]{1,})$")
        || Regex.IsMatch(name, "^([A-Z]{1}[a-z]{1,}) ([A-Z]{1}[a-z]{1,}) ([A-Z]{1}[a-z]{1,})$");
    
    // 15 https://edabit.com/challenge/ZLM2e2d3ATvjzkxT7
    public static string sorting(string str) 
    {
        string map = string.Join("",
                         "abcdefghijklmnopqrstuvwxyz".Select(c => c + char.ToUpper(c).ToString()))
                     + "0123456789";
            
        return new string(str.OrderBy(c => map.IndexOf(c)).ToArray());
    }
}