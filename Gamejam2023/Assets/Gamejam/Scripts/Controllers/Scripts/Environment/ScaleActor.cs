using System;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment
{
    public class ScaleActor : BaseInteractable
    {

        [SerializeField] private Vector3 targetScale = Vector3.one;
        [SerializeField] private float scaleTime = 1;

        public bool isScaleActive;
        private Vector3 startScale = Vector3.one;
        private float startScaleTime = 0;

        private void Awake()
        {
            startScaleTime = Time.time;
            startScale = transform.localScale;
        }

        private void FixedUpdate()
        {
            var currentScale = transform.localScale;
            if (isScaleActive)
            {
                transform.localScale = GetScale(currentScale, targetScale);
            }
            else
            {
                transform.localScale = GetScale(currentScale, startScale);
            }
        }

        private Vector3 GetScale(Vector3 currentScale, Vector3 targetScale)
        {
            Vector3 scale = Vector3.Lerp(currentScale, targetScale, (Time.time - startScaleTime) / scaleTime);
            
            return scale;
        }

        public override void OnToggle(bool isActive)
        {
            base.OnToggle(isActive);

            startScaleTime = Time.time;
            isScaleActive = isActive;
        }
    }
}