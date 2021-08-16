using System;

namespace IdleGame.Player
{
    public static class Player
    {
        public static int Score { get; private set; }

        public static event Action<int> ScoreUpdated;

        public static void IncreaseScore(int value)
        {
            if (value < 1)
                return;

            Score += value;
            ScoreUpdated?.Invoke(Score);
        }

        public static void ResetScore()
        {
            Score = 0;
            ScoreUpdated?.Invoke(Score);
        }

        public static int GetBestScore()
        {
            return SaveSystem.GetBestScore();
        }
    }
}