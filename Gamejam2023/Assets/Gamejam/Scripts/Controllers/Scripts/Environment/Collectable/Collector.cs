using System;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment.Collectable
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] private int maxCount = 1;
        
        public int Count => counter;
        public int MaxCount => maxCount;
        
        private int counter = 0;

        public event Action<int> CountChanged;
        public event Action AllCollected;

        public void Claim(CollectableTypes collectable)
        {
            counter++;
            
            CountChanged?.Invoke(counter);

            if (counter >= maxCount)
            {
                AllCollected?.Invoke();
            }
        }
    }
}