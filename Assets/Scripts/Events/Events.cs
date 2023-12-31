﻿using System;

namespace Events
{
    public static class Events
    {
        public static Action FightComplete;
        public static Action LevelComplete;

        public static Action AttackButton;
        public static Action DefenseButton;

        public static Action PropertyChanged;

        public static Action LevelFailed;
        
        public static void OnLevelComplete()
        {
            LevelComplete?.Invoke();
        }
        
        public static void OnFightComplete()
        {
            FightComplete?.Invoke();
        }

        public static void OnAttackButton()
        {
            AttackButton?.Invoke();
        }

        public static void OnDefenseButton()
        {
            DefenseButton?.Invoke();
        }

        public static void OnPropertyChanged()
        {
            PropertyChanged?.Invoke();
        }

        public static void OnLevelFailed()
        {
            LevelFailed?.Invoke();
        }
    }
}