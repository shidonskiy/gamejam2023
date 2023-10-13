using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment
{
    public class BaseInteractable : MonoBehaviour
    {
        protected bool backToDefault = false;
        
        public virtual void OnToggle(bool isActive)
        {
            backToDefault = false;
        }

        public virtual void BackToDefault()
        {
            backToDefault = true;
        }
    }
}