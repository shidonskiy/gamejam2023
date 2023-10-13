using System;
using Gamejam.Scripts.Controllers.Scripts.Environment.Collectable;
using TMPro;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.UI
{
    public class GameplayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI collectionText;
        [SerializeField] private Collector collector;

        private void OnEnable()
        {
            collector.CountChanged += CollectorOnCountChanged;
            collectionText.text = $"COLLECTION: {collector.Count}";
        }
        
        private void OnDisable()
        {
            collector.CountChanged -= CollectorOnCountChanged;
        }
        
        private void CollectorOnCountChanged(int count)
        {
            collectionText.text = $"COLLECTION: {count}";
        }
    }
}