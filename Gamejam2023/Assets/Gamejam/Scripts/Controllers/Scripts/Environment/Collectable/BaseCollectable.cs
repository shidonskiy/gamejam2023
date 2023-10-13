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
                var collector = other.GetComponentInParent<Collector>();
                if(collector != null)
                {
                    collector.Claim(itemType);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}