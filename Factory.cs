namespace CourseWork;

public static class Factory
{
    public static Game CreateGame(GameAccount player1, GameAccount player2, int index, int rating)
    {
        if (index == 2)
        {
            return new TrainingGame(player1, player2);
        }

        return new DefaultGame(player1, player2, rating);
    }
}