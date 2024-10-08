using System;
internal class Program
{
	private static void Main(string[] args)
	{
		bool isRunning = true;
		while (isRunning)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("task-cli ");

			Console.ForegroundColor = ConsoleColor.Yellow;
			string? input = Console.ReadLine();
			if (input != null)
			{
				switch (input.ToLower())
				{
					case "exit":
						isRunning = false;
						Console.WriteLine("Program shutdown");
						break;

					default:
						Console.WriteLine("output");
						break;
				}
			}
		}
	}
}