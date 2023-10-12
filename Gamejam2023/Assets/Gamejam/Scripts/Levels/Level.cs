using System;
using System.Collections;
using System.Collections.Generic;
using GameJam.Scripts.Controllers;
using GameJam.Scripts.Obstacles;
using GameJam.Scripts.Obstacles.States;
using GameJam.Scripts.Systems;
using GameJam.Scripts.UI.Windows;
using UnityEngine;

namespace GameJam.Scripts.Levels
{
    public class Level : BaseLevel
    {
        [SerializeField] private Player _player;
        
        private Coroutine _transitionRoutine;
        
        public event Action RestartLevel;
        public event Action LevelCompleted;

        public override void Setup(Game game)
        {
            base.Setup(game);

            LevelWindow window = Game.WindowManager.OpenWindow<LevelWindow>(WindowManager.WindowMode.Clear);
            window.Setup(Game, this);
        }

        public void ShowAll()
        {
        }

        private void Awake()
        {
            _player.Death += PlayerOnDeath;
            _player.LevelFinished += PlayerOnLevelFinished;
        }

        private void PlayerOnLevelFinished()
        {
            LevelComplete();
        }

        private void PlayerOnDeath()
        {
            Restart();
        }

        private void Start()
        {
        }

        private void Update()
        {
        }

        public void Restart()
        {
            RestartLevel?.Invoke();
        }
        
        public void LevelComplete()
        {
            OnLevelCompleted();
        }

        protected virtual void OnLevelCompleted()
        {
            LevelCompleted?.Invoke();
        }
    }
}