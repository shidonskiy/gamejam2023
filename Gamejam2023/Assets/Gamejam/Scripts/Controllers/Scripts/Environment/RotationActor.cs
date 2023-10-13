using System;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment
{
    public class RotationActor : BaseInteractable
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 rotationAxis = Vector3.forward;

        [SerializeField] private float rotationSpeed;

        [SerializeField] private Transform rotateTo;

        [SerializeField] private bool isRotationActive = false;

        private Quaternion startLocalRotation;

        private void Awake()
        {
            startLocalRotation = target.localRotation;
        }

        private void FixedUpdate()
        {
            if (isRotationActive && !backToDefault)
            {
                Rotate();
            }
            else if (backToDefault)
            {
                target.localRotation =
                    Quaternion.RotateTowards(target.localRotation, startLocalRotation, rotationSpeed * Time.deltaTime);
            }
        }

        private void Rotate()
        {
            if (rotateTo != null)
            {
                var localForward = transform.InverseTransformDirection(rotateTo.forward);
                var localUp = transform.InverseTransformDirection(rotateTo.up);

                var rotation = Quaternion.LookRotation(rotateTo.forward, rotateTo.up);

                target.rotation =
                    Quaternion.RotateTowards(target.rotation, rotation, rotationSpeed * Time.fixedDeltaTime);
            }
            else
            {
                var angle = Quaternion.Euler(Vector3.Cross(transform.forward, rotationAxis) * (rotationSpeed * Time.fixedDeltaTime));

                Quaternion rotation = Quaternion.AngleAxis(rotationSpeed * Time.fixedDeltaTime, rotationAxis);
                target.localRotation *= rotation;
            }
        }

        public override void OnToggle(bool isActive)
        {
            base.OnToggle(isActive);

            isRotationActive = isActive;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(target.position, target.position + rotationAxis.normalized);
        }
    }
}