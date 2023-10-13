using GameJam.Scripts.Utils;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment.Collectable
{
    [RequireComponent(typeof(Collider))]
    public class BaseCollectable : MonoBehaviour
    {
        [SerializeField] private CollectableTypes itemType;

        protected void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == Layers.Player)
            {
                if(other.TryGetComponent<Collector>(out var collector))
                {
                    collector.Claim(itemType);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}