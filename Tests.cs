using NUnit.Framework;
// ReSharper disable RedundantExplicitArrayCreation

namespace salt_rat;

[TestFixture]
public class Tests
{
	// 8 https://edabit.com/challenge/ErLPB5BcrE7yhHhKN
	[Test]
	[TestCase(ExpectedResult = true)]
	public static bool FixedTest() => edabit.ReturnTrue();

	// 7 https://edabit.com/challenge/xfRucdwGksiyjZq4K
	[Test]
	[TestCase(2, 3, ExpectedResult = 5)]
	[TestCase(-3, -6, ExpectedResult = -9)]
	[TestCase(7, 3, ExpectedResult = 10)]
	public static int FixedTest(int a, int b)
	{
		Console.WriteLine($"Input: {a}, {b}");
		return edabit.Sum(a, b);
	}
	// 6 https://edabit.com/challenge/FKb8JY75nkaHz7B3F
	[Test]
	[TestCase(12, ExpectedResult = 13)]
	[TestCase(24, ExpectedResult = 29)]
	[TestCase(11, ExpectedResult = 11)]
	[TestCase(13, ExpectedResult = 13)]
	[TestCase(14, ExpectedResult = 17)]
	[TestCase(33, ExpectedResult = 37)]
	public static int NextPrime(int num)
	{
		Console.WriteLine($"Input: {num}");
		return edabit.NextPrime(num);
	}

	// 2 https://edabit.com/challenge/8tyXtHqAT3LAuHMqu
	[Test]
	[TestCase("#CD5C5C", ExpectedResult = true)]
	[TestCase("#EAECEE", ExpectedResult = true)]
	[TestCase("#eaecee", ExpectedResult = true)]
	[TestCase("#CD5C58C", ExpectedResult = false, Description = "Length exceeds 6.")]
	[TestCase("#CD5C5Z", ExpectedResult = false, Description = "Alphabetic characters not in A-F.")]
	[TestCase("#CD5C&C", ExpectedResult = false, Description = "Unacceptable character.")]
	[TestCase("CD5C5C", ExpectedResult = false, Description = "Does not start with #.")]
	[TestCase("#123CCCD", ExpectedResult = false, Description = "Length exceeds 6.")]
	[TestCase("#123456", ExpectedResult = true)]
	[TestCase("#987654", ExpectedResult = true)]
	[TestCase("#9876543", ExpectedResult = false, Description = "Length exceeds 6.")]
	[TestCase("#CCCCCC", ExpectedResult = true)]
	[TestCase("#ZCCZCC", ExpectedResult = false, Description = "Not acceptable alphabetic characters.")]
	[TestCase("#Z88Z99", ExpectedResult = false, Description = "Not acceptable alphabetic characters.")]
	[TestCase("#Z88!99", ExpectedResult = false, Description = "Unacceptable character.")]
	public static bool IsValidHexCode(string str)
	{
		Console.WriteLine($"Input: {str}");
		return edabit.IsValidHexCode(str);
	}

	// 10 https://edabit.com/challenge/etT7orqDDXJF2zGYM
	[Test]
	// INVALID PASSWORDS
	[TestCase("P1zz@", ExpectedResult = false)]
	[TestCase("P1zz@P1zz@P1zz@P1zz@P1zz@", ExpectedResult = false)]
	[TestCase("mypassword11", ExpectedResult = false)]
	[TestCase("MYPASSWORD11", ExpectedResult = false)]
	[TestCase("iLoveYou", ExpectedResult = false)]
	[TestCase("Pè7$areLove", ExpectedResult = false)]
	[TestCase("Repeeea7!", ExpectedResult = false)]
	// VALID PASSWORDS
	[TestCase("H4(k+x0", ExpectedResult = true)]
	[TestCase("Fhg93@", ExpectedResult = true)]
	[TestCase("aA0!@#$%^&*()+=_-{}[]:;\"", ExpectedResult = true)]
	[TestCase("zZ9'?<>,.", ExpectedResult = true)]
	public static bool FixedTest(string password) => edabit.ValidatePassword(password);

	// 5 https://edabit.com/challenge/2QvnWexKoLfcJkSsc
	[Test]
	[TestCase(7, 5, ExpectedResult = new int[] {7, 14, 21, 28, 35})]
	[TestCase(12, 10, ExpectedResult = new int[] {12, 24, 36, 48, 60, 72, 84, 96, 108, 120})]
	[TestCase(17, 7, ExpectedResult = new int[] {17, 34, 51, 68, 85, 102, 119})]
	[TestCase(630, 14,
		ExpectedResult = new int[] {630, 1260, 1890, 2520, 3150, 3780, 4410, 5040, 5670, 6300, 6930, 7560, 8190, 8820})]
	[TestCase(140, 3, ExpectedResult = new int[] {140, 280, 420})]
	[TestCase(7, 8, ExpectedResult = new int[] {7, 14, 21, 28, 35, 42, 49, 56})]
	[TestCase(11, 21,
		ExpectedResult = new int[]
			{11, 22, 33, 44, 55, 66, 77, 88, 99, 110, 121, 132, 143, 154, 165, 176, 187, 198, 209, 220, 231})]
	public static int[] FixedTest3(int num, int len) => edabit.ArrayOfMultiples(num, len);

	// 9 https://edabit.com/challenge/wrxoYop5uZKG4nNSb
	[TestCase(new int[] {0, 1, -1, -1, 2}, ExpectedResult = "{ { 0, 1, -1 }, { -1, -1, 2 } }")]
	[TestCase(new int[] {0, 0, 0, 5, -5}, ExpectedResult = "{ { 0, 0, 0 }, { 0, 5, -5 } }")]
	[TestCase(new int[] {0, -1, 1, 0, -1, 1},
		ExpectedResult = "{ { 0, -1, 1 }, { 0, 1, -1 }, { -1, 1, 0 }, { -1, 0, 1 }, { 1, 0, -1 } }")]
	[TestCase(new int[] {0, 5, 5, 0, 0}, ExpectedResult = "{ { 0, 0, 0 } }")]
	[TestCase(new int[] {0, 5, -5, 0, 0}, ExpectedResult = "{ { 0, 5, -5 }, { 0, 0, 0 }, { 5, -5, 0 } }")]
	[TestCase(new int[] {1, 2, 3, -5, 8, 9, -9, 0}, ExpectedResult = "{ { 1, 8, -9 }, { 2, 3, -5 }, { 9, -9, 0 } }")]
	[TestCase(new int[] {0, 0, 0}, ExpectedResult = "{ { 0, 0, 0 } }")]
	[TestCase(new int[] {1, 5, 5, 2}, ExpectedResult = "{  }")]
	[TestCase(new int[] {1, 1}, ExpectedResult = "{  }")]
	[TestCase(new int[] { }, ExpectedResult = "{  }")]
	public static string TestThreeSum(int[] arr)
	{
		var res = edabit.ThreeSum(arr);
		var result = string.Join(", ", res.Select(itm => $"{{ {itm[0]}, {itm[1]}, {itm[2]} }}"));
		return "{ " + result + " }";
	}

	// 4 https://edabit.com/challenge/JYEufqRvkusjr5R58
	[Test]
	[TestCase("There is a bomb.", ExpectedResult = "Duck!!!")]
	[TestCase("Hey, did you find it?", ExpectedResult = "There is no bomb, relax.")]
	[TestCase("Hey, did you think there is a bomb?", ExpectedResult = "Duck!!!")]
	[TestCase("This goes boom!!!", ExpectedResult = "There is no bomb, relax.")]
	[TestCase("Hey, did you find the BoMb?", ExpectedResult = "Duck!!!")]
	[TestCase("Commotion in the third, a bomb is found!", ExpectedResult = "Duck!!!")]
	public static string FixedTest2(string a) => edabit.Bomb(a);

	// 3 https://edabit.com/challenge/F6m5ZRyzK5fmqTrBG
	[Test]
	[TestCase(2, ExpectedResult = 1)]
	[TestCase(3, ExpectedResult = 7)]
	[TestCase(10, ExpectedResult = 6)]
	[TestCase(6, ExpectedResult = 8)]
	[TestCase(345, ExpectedResult = 125)]
	[TestCase(72, ExpectedResult = 22)]
	public static int FixedTest(int num)
	{
		Console.WriteLine($"Input: {num}");
		return edabit.collatz(num);
	}

	// 1 https://edabit.com/challenge/NYa5fkHAukJmuhn3W
	[TestCase("10001", ExpectedResult = 1)]
	[TestCase("00101", ExpectedResult = 1)]
	[TestCase("0", ExpectedResult = 1)]
	[TestCase("000", ExpectedResult = 2)]
	[TestCase("001000100000001010001010010000001000101000000", ExpectedResult = 12)]
	[TestCase(
		"010000100000000010010000001010000000010100001000000010010000000001000000001000000010000000100100000000100000100100010000001",
		ExpectedResult = 35)]
	[TestCase(
		"10001000000100000010000001000100000001010000001000100010010000000010000010001000000010010010000000001001001000000010000000100000001010000000100000000010000000100010000010000010000001000100001001001000000100000010000010100000001000000000",
		ExpectedResult = 69)]
	[TestCase(
		"00100100100000100100000001000001000001010000010000000100000010001001000100000001001000001010000001000010100001000010000000010010000000100100000100000000100100000100000000100010001000010000001001000000001000100000100000001000100100000010000000010000100000001000100001010000000100000100000001000100000000101001000001000000010100000010000010000000100000000100100100000001010010000010100100010000000010010000001000010000010000100000",
		ExpectedResult = 115)]
	[TestCase(
		"0010000001000000101000000001000100000001001010000000101000000001010100001000010001000001000010000010001000100000000100000100000010100010000100000010100000001000000001010000000100010000100000000100000001000010000000101010100010100000001000001000000001000010000010000000100100000010000100000100100000001000000010000000100010101000000010010100000000100000100000000101000000010000010000010000000010100000100000001000010000100000010000000010000000100000000100000001000000010000000010010010000001000000100001010000100100000001000001000000100001000000001000000100000100001000010000100001000001001010001001000001000001000001000001000000010001000010000010001000000100000000100100001000000010000001010000100010000000100010100100000000100000001010010100010000000100000010000000010000001010010000000100000000100000100000000100000000100000001010000001000100000100000010000010000010100000100010000100000100001010101000010100010000010100000000100100010000010000010101000001000000010001000000100000001001000000100010000000010000001000100000100000001000000101001010000010000000010010000000010000001000010000",
		ExpectedResult = 303)]
	public static int TestSolution(string beach) => edabit.SunLoungers(beach);

	// 11 https://edabit.com/challenge/8n43m5c64BKfGCWr3
	[TestCase("mubashirhassan", "crazy", ExpectedResult = "bmusarhiahass n")]
	[TestCase("edabitisamazing", "matt", ExpectedResult = "deabtiismaaznig ")]
	[TestCase("Pakistanisamazing", "airforce", ExpectedResult = "Paniasktiinmsaazg       ")]
	[TestCase("iloveher", "612345", ExpectedResult = "lovehir    e")]
	[TestCase("iwillquitsoon", "endisnear", ExpectedResult = "iiiulwqtl os no   ")]
	public static string TestSolution(string msg, string key) => edabit.NicoCipher(msg, key);

	// 12 https://edabit.com/challenge/8JegGd37XazwMJvs6
	[TestCase(1, ExpectedResult = "invalid")]
	[TestCase(3, ExpectedResult = "b, a, ab")]
	[TestCase(7, ExpectedResult = "b, a, ab, aba, abaab, abaababa, abaababaabaab")]
	[TestCase(10,
		ExpectedResult =
			"b, a, ab, aba, abaab, abaababa, abaababaabaab, abaababaabaababaababa, abaababaabaababaababaabaababaabaab, abaababaabaababaababaabaababaabaababaababaabaababaababa")]
	[TestCase(15,
		ExpectedResult =
			"b, a, ab, aba, abaab, abaababa, abaababaabaab, abaababaabaababaababa, abaababaabaababaababaabaababaabaab, abaababaabaababaababaabaababaabaababaababaabaababaababa, abaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaab, abaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababa, abaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaab, abaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababa, abaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaababaababaabaababaababaabaababaabaababaababaabaababaabaab")]
	public static string TestSolution(int n) => edabit.FiboWord(n);

	// 13 https://edabit.com/challenge/FXt7yKLgFi7SW6JBa
	[Test]
	[TestCase(ExpectedResult = 13.5)]
	public static double FixedTest1() => edabit.UniqueFract();

	// 14 https://edabit.com/challenge/pcHzxfGheeNE4JDpR
	[Test]
	[TestCase("H. Wells", ExpectedResult = true)]
	[TestCase("H. G. Wells", ExpectedResult = true)]
	[TestCase("Herbert G. Wells", ExpectedResult = true)]
	[TestCase("Herbert George Wells", ExpectedResult = true)]
	[TestCase("Herbert", ExpectedResult = false, Description = "Name must be 2 or 3 words.")]
	[TestCase("Herbert W. G. Wells", ExpectedResult = false, Description = "Name must be 2 or 3 words")]
	[TestCase("h. Wells", ExpectedResult = false, Description = "Incorrect Capitalization.")]
	[TestCase("herbert G. Wells", ExpectedResult = false, Description = "Incorrect Capitalization.")]
	[TestCase("H Wells", ExpectedResult = false, Description = "Initials must end with a dot.")]
	[TestCase("Herb. Wells", ExpectedResult = false, Description = "Words cannot end with a dot.")]
	[TestCase("H. George Wells", ExpectedResult = false,
		Description = "First name is initial but middle name is word.")]
	[TestCase("Herbert George W.", ExpectedResult = false, Description = "Last name cannot be an initial.")]
	public static bool ValidName(string name)
	{
		Console.WriteLine($"Input: {name}");
		return edabit.ValidName(name);
	}

	// 15 https://edabit.com/challenge/ZLM2e2d3ATvjzkxT7
	[Test]
	[TestCase("eA2a1E", ExpectedResult = "aAeE12")]
	[TestCase("Re4r", ExpectedResult = "erR4")]
	[TestCase("6jnM31Q", ExpectedResult = "jMnQ136")]
	[TestCase("f5Eex", ExpectedResult = "eEfx5")]
	[TestCase("846ZIbo", ExpectedResult = "bIoZ468")]
	[TestCase("2lZduOg1jB8SPXf5rakC37wIE094Qvm6Tnyh", ExpectedResult = "aBCdEfghIjklmnOPQrSTuvwXyZ0123456789")]
	public static string Fixed3Test(string str) => edabit.sorting(str);
}


