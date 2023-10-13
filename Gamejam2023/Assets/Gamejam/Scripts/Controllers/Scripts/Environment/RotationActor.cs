using System;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment
{
    public class RotationActor : BaseInteractable
    {
        [SerializeField] private Vector3 rotationAxis = Vector3.forward;

        [SerializeField] private float rotationSpeed;

        [SerializeField] private Transform rotateTo;

        [SerializeField] private bool isRotationActive = false;

        private Quaternion startLocalRotation;

        private void Awake()
        {
            startLocalRotation = transform.localRotation;
        }

        private void FixedUpdate()
        {
            if (isRotationActive)
            {
                Rotate();
            }
            else
            {
                transform.localRotation =
                    Quaternion.RotateTowards(transform.localRotation, startLocalRotation, rotationSpeed * Time.deltaTime);
            }
        }

        private void Rotate()
        {
            if (rotateTo != null)
            {
                var localForward = transform.InverseTransformDirection(rotateTo.forward);
                var localUp = transform.InverseTransformDirection(rotateTo.up);

                var rotation = Quaternion.LookRotation(rotateTo.forward, rotateTo.up);

                transform.rotation =
                    Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                var angle = Quaternion.Euler(Vector3.Cross(transform.forward, rotationAxis) * (rotationSpeed * Time.deltaTime));

                Quaternion rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, rotationAxis);
                transform.localRotation *= rotation;
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
            Gizmos.DrawLine(transform.position, transform.position + rotationAxis.normalized);
        }
    }
}