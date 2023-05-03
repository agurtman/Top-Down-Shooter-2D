public static class Stats
{
    public static int Level { get; private set; } = 1;
    private static int score = 0;

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;

            if (score > 100 * Level)
            {
                Level++;
                score = 0;
                Shop.money += Level * 50;
            }
        }
    }

    public static void ResetAllStats()
    {
        Level = 1;
        score = 0;
    }
}
