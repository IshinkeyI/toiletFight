using System;

namespace Events
{
    public static class Events
    {
        public static Action FightComplete;
        public static Action LevelComplete;

        public static void OnLevelComplete()
        {
            LevelComplete?.Invoke();
        }
        
        public static void OnFightComplete()
        {
            FightComplete?.Invoke();
        }
    }
}