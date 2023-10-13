using System.Collections;
using GameJam.Scripts.Utils;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment.Collectable
{
    [RequireComponent(typeof(Collider))]
    public class BaseCollectable : MonoBehaviour
    {
        [SerializeField] private CollectableTypes itemType;

        [SerializeField] private ParticleSystem claimParticles;

        private bool isClaimed = false;

        protected void OnTriggerEnter(Collider other)
        {
            if (isClaimed)
            {
                return;
            }
            
            if (other.gameObject.layer == Layers.Player)
            {
                var collector = other.GetComponentInParent<Collector>();
                if(collector != null)
                {
                    isClaimed = true;
                    collector.Claim(itemType);
                    StartCoroutine(DisableRoutine());
                }
            }
        }

        private IEnumerator DisableRoutine()
        {
            claimParticles.gameObject.SetActive(true);
            claimParticles.Play();
            yield return new WaitForSeconds(1);
            claimParticles.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}