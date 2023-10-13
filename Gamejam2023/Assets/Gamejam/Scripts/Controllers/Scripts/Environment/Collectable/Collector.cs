using System;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment.Collectable
{
    public class Collector : MonoBehaviour
    {
        public int Count => counter;
        
        private int counter = 0;

        public event Action<int> CountChanged;

        public void Claim(CollectableTypes collectable)
        {
            counter++;
            
            CountChanged?.Invoke(counter);
        }
    }
}