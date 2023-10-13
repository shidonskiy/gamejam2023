using System;
using TMPro;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.UI
{
    public class GameplayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI collectionText;

        private int maxCount;

        private void OnEnable()
        {
            Time.timeScale = 1;
        }
        
        private void OnDisable()
        {
            Time.timeScale = 0;
        }

        public void Setup(int max)
        {
            maxCount = max;
            collectionText.text = $"COLLECTION: 0 : {maxCount}";
        }

        public void UpdateCount(int count)
        {
            collectionText.text = $"COLLECTION: {count} : {maxCount}";
        }
    }
}