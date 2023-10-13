using System;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment
{
    public class ForceActor : BaseInteractable
    {
        [SerializeField]
        float force = 9.81f;

        [SerializeField]
        public Bounds boundaryDistance = new Bounds(Vector3.zero, Vector3.one);

        private void OnEnable()
        {
            CustomGravity.RegisterForce(this);
        }

        private void OnDisable()
        {
            CustomGravity.UnregisterForce(this);
        }

        public Vector3 GetForce(Vector3 position)
        {
            var localPos = transform.InverseTransformPoint(position);
            
            if (boundaryDistance.Contains(localPos))
            {
                return transform.up * force;
            }

            return Vector3.zero;
        }
        
        public override void OnToggle(bool isActive)
        {
            Activate(isActive);
        }

        protected virtual void Activate(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}