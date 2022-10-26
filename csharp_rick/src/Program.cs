static class Program
{
	public static Random rnd = new Random();
	
	private static Stats stats = new Stats();
	
	private static void whoops(string message)
	{
		Console.Error.WriteLine(message);
		Environment.Exit(1);
	}
	
	private static void roll(int rolls, bool isInfinite)
	{
		StateBase current = new SNever();
		
		// Lines
		for (; isInfinite || stats.lines < rolls; stats.lines++)
		{
			string lineBuffer = "";
			bool isLineDone = false;
			
			// Words
			while (!isLineDone)
			{
				StateReturns res = current.runState();
				lineBuffer += res.Text;
				
				if (res.Next.GetType() == typeof(SNever))
					isLineDone = true;
				else
					lineBuffer += ' ';
				
				stats.allWordsCount++;
				//TODO: this word counter
				
				current = res.Next;
			}
			
			// Print a whole line at once rather than words.
			// Better performance and cleaner scrolling.
			Console.WriteLine(lineBuffer);
		}
	}
	
	static void Main(string[] args)
	{
		switch (args.Count())
		{
			case 0:
				roll(69420, false);
				break;
			case 1:
				int requestedLines = 0;
				try { requestedLines = Int32.Parse(args[0]); }
				catch (Exception) { whoops("Argument 1 couldn't be parsed as an integer number."); }
				
				if (requestedLines < 0)
					roll(123, true);
				else
					roll(requestedLines, false);
				
				break;
			default:
				whoops("Bad argument count.\nExpected:\nNo arguments (generate default amount of lines, 69420)\n1 argument (generate this amount of lines OR negative number for infinity)");
				break;
		}
		
		stats.print();
	}
}