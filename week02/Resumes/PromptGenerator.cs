public class PromptGenerator
{
	private readonly List<string> _prompts = new List<string>
	{
		"What was the best part of your day?",
		"Who did you help today?",
		"What is something you learned recently?",
		"What are you looking forward to?",
		"What made you smile today?"
	};

	private readonly Random _random = new Random();

	public string GetRandomPrompt()
	{
		return _prompts[_random.Next(_prompts.Count)];
	}
}
