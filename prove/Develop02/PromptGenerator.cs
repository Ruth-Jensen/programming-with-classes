public class PromptGenerator
{
    public string[] _prompts = new string[]
    {
        "How did you overcome challenges or setbacks that happened today?",
        "What steps did you take today to move closer to achieving your goals, and were there any unexpected obstacles?",
        "Who had a significant impact on your day, either positively or negatively, and how did it influence your overall experience?",
        "Did you encounter any fears or insecurities today, and how did you manage or overcome them?",
        "What decision did you make today that stands out, and what factors influenced that decision?",
        "Is there a specific place you visited or thought about today that holds special meaning for you, and why?",
        "What did you learn from an interaction with someone today that left an impact on you, and how might it shape future interactions?",
        "Who or what are you thankful for today, make a list as ling as you can.",
        "Were you pushed out of your comfort zone today? and what did you learn from doing unfamiliar things?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today? What caused it?",
        "If I had one thing I could do over today, what would it be?",
        "What unexpected joy or surprise brightened your day today?",
        "Were there any moments when you had to exercise patience? How did you handle those situations? How can you do better?",
        "How did you demonstrate kindness or empathy toward others today? Discribe your experience. How did you feel?",
        "Were there any instances where you had to adapt to change? What did you learn from those experiences?",
        "Was there so one inspired or motivated you today? What did they do that you liked?",
        "Did you do so thing today that you are particularly proud of?",
        "How did you express gratitude today, either internally or to those around you?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Length);
        return _prompts[index];
    }
}