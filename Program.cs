using quest_quiz.Core;

namespace quest_quiz;
public static class Program
{
    public static void Main(string[] args)
    {
        QuestQuiz game = new();
        game.Run();
    }
}