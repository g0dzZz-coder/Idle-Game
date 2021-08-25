using System;

namespace IdleGame.Player
{
    public static class Player
    {
        public static int Score { get; private set; }

        public static event Action<int> ScoreChanged;

        public static void IncreaseScore(int value)
        {
            if (value < 1)
                return;

            Score += value;
            ScoreChanged?.Invoke(Score);
        }

        public static void DecreaseScore(int value)
        {
            if (value < 1)
                return;

            Score -= value;
            if (Score < 0)
                Score = 0;

            ScoreChanged?.Invoke(Score);
        }

        public static void ResetScore()
        {
            Score = 0;
            ScoreChanged?.Invoke(Score);
        }

        public static int GetBestScore()
        {
            return SaveSystem.GetBestScore();
        }
    }
}