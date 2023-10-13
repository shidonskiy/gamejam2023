using System;
using System.Collections;
using System.Collections.Generic;
using Gamejam.Scripts.Controllers.Scripts.Environment.Collectable;
using Gamejam.Scripts.Controllers.Scripts.UI;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gamejam.Scripts.Controllers.Scripts
{
    public class Game : MonoBehaviour
    {
        public static Game Instance { get; private set;}
        
        [SerializeField] private StartView startView;
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private CompleteView completeView;
        [SerializeField] private GameplayView gameplayView;

        [SerializeField] private List<string> scenes;

        private Collector collector;

        private GameObject currentView;
        private int currentLevelIndex;

        private void Awake()
        {
            Instance = this;
            GoToMainscreen();
        }

        public void OnBack()
        {
            if (currentView != null && currentView.GetComponent<GameplayView>())
            {
                GoToPause();
            }
        }

        public void GoToMainscreen()
        {
            UpdateCurrentView(startView.gameObject);
        }

        public void GoToPause()
        {
            if (currentView.GetComponent<GameplayView>() != null)
            {
                UpdateCurrentView(pauseMenu.gameObject);
            }
        }

        public void GoToComplete()
        {
            UpdateCurrentView(completeView.gameObject);
        }

        public void GoToGameplay()
        {
            UpdateCurrentView(gameplayView.gameObject);
        }

        public void UpdateCurrentLevel(int index)
        {
            currentLevelIndex = index;
        }

        public void StartNextLevel()
        {
            if (scenes.Count > currentLevelIndex + 1)
            {
                currentLevelIndex++;

                StartLevel(scenes[currentLevelIndex]);
            }
        }

        public void StartLevel(int index)
        {
            StartLevel(scenes[index]);
        }

        public void StartLevel(string levelName)
        {
            if (collector != null)
            {
                collector.CountChanged -= CollectorOnCountChanged;
                collector.AllCollected -= CollectorOnAllCollected;
            }

            StartCoroutine(LevelLoadRoutine(levelName));
        }

        private void CollectorOnAllCollected()
        {
            GoToComplete();
        }

        private void CollectorOnCountChanged(int count)
        {
            
            gameplayView.UpdateCount(count);
        }

        public void RestartLevel()
        {
            StartLevel(SceneManager.GetActiveScene().name);
        }

        private void UpdateCurrentView(GameObject newView)
        {
            if (currentView != null)
            {
                currentView.SetActive(false);
            }

            currentView = newView;
            currentView.SetActive(true);
        }
        
        private IEnumerator LevelLoadRoutine(string name)
        {
            var result = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);

            while (!result.isDone)
            {
                yield return null;
            }
            
            Scene scene = SceneManager.GetSceneByName(name);
            foreach (var root in scene.GetRootGameObjects())
            {
                collector = root.GetComponentInChildren<Collector>();

                if (collector != null)
                {
                    break;
                }
            }
            
            if (collector != null)
            {
                gameplayView.Setup(collector.MaxCount);
                collector.CountChanged += CollectorOnCountChanged;
                collector.AllCollected += CollectorOnAllCollected;
            }
            
            GoToGameplay();
        }
    }
}