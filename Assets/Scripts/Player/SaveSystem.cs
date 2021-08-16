using UnityEngine;

namespace IdleGame.Player
{
    public static class SaveSystem
    {
        private static int LastBestScore;

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            GetBestScore();

            Player.ScoreUpdated += SaveScore;
        }

        public static void SaveScore(int value)
        {
            if (IsBestScore(value) == false)
                return;

            PlayerPrefs.SetInt("BestScore", value);
            PlayerPrefs.Save();
        }

        public static int GetBestScore()
        {
            LastBestScore = PlayerPrefs.GetInt("BestScore", 0);
            return LastBestScore;
        }

        private static bool IsBestScore(int value)
        {
            if (value < LastBestScore)
                return false;

            return true;
        }
    }
}