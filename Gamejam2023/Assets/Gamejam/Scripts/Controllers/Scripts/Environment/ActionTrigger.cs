using UnityEngine;
using UnityEngine.Events;

namespace Gamejam.Scripts.Controllers.Scripts.Environment
{
    [RequireComponent(typeof(Collider))]
    public class ActionTrigger : MonoBehaviour
    {
        public UnityEvent<bool> OnToggle;

        protected void OnTriggerEnter(Collider other)
        {
            OnToggle.Invoke(true);
        }

        protected void OnTriggerExit(Collider other)
        {
            OnToggle.Invoke(false);
        }
    }
}