using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment
{
    public class BaseInteractable : MonoBehaviour
    {
        public bool isToggle;

        public virtual void OnToggle(bool isActive)
        {
            
        }
    }
}