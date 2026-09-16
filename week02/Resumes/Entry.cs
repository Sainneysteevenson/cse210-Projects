
using System.Text;

public class Entry
{
	public string Date { get; }
	public string Prompt { get; }
	public string Response { get; }

	public Entry(string prompt, string response)
	{
		Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		Prompt = prompt;
		Response = response;
	}

	private Entry(string date, string prompt, string response)
	{
		Date = date;
		Prompt = prompt;
		Response = response;
	}

	public string ToFileLine()
	{
		return string.Join("|", Encode(Date), Encode(Prompt), Encode(Response));
	}

	public static Entry FromFileLine(string line)
	{
		string[] parts = line.Split('|');
		if (parts.Length != 3)
		{
			throw new FormatException("The journal file contains an invalid entry.");
		}

		return new Entry(Decode(parts[0]), Decode(parts[1]), Decode(parts[2]));
	}

	public void Display()
	{
		Console.WriteLine($"Date: {Date}");
		Console.WriteLine($"Prompt: {Prompt}");
		Console.WriteLine($"Response: {Response}");
		Console.WriteLine();
	}

	private static string Encode(string value)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(value ?? string.Empty));
	}

	private static string Decode(string value)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String(value));
	}
}

