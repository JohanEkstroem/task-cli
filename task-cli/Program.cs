using System;
internal class Program
{
	private static void Main(string[] args)
	{
		bool isRunning = true;
		Console.WriteLine("Hello world!");
		while (isRunning)
		{
			string input = Console.ReadLine();

			switch (input.ToLower())
			{
				case "exit":
					isRunning = false;
					System.Console.WriteLine("Programmet avslutas");
					break;

				default:
					System.Console.WriteLine(input);
					break;
			}
		}
	}
}