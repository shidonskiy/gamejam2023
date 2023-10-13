using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment.Collectable
{
    public class Collector : MonoBehaviour
    {
        public int Count => counter;
        
        private int counter = 0;
        
        public void Claim(CollectableTypes collectable)
        {
            counter++;
        }
    }
}