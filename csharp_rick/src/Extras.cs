class Stats
{
	public int lines;
	public int allWordsCount;
	public Dictionary<string, int> eachWordCount = new Dictionary<string, int>();
	
	public void print()
	{
		Console.WriteLine("---RICK SUCCESSFULLY ROLLED.---");
		Console.WriteLine("[STATS]");
		Console.WriteLine($"Lines: {lines}");
		Console.WriteLine($"Words: {allWordsCount}");
		foreach(KeyValuePair<string, int> entry in eachWordCount)
		{
			Console.WriteLine($"{entry.Key}: {entry.Value}");
		}
	}
}