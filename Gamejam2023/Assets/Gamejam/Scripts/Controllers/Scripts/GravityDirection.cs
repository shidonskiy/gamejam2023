using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts
{
    public class GravityDirection : GravitySource
    {
        [SerializeField]
        float gravity = 9.81f;

        [SerializeField]
        Vector3 boundaryDistance = Vector3.one;

        public override Vector3 GetGravity(Vector3 position)
        {
            position = transform.InverseTransformDirection(position - transform.position);

            Bounds b = new Bounds(Vector3.zero, boundaryDistance);
            if (b.Contains(position))
            {
                return Vector3.up * gravity;
            }

            return Vector3.zero;
        }

        void OnDrawGizmos () {
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(Vector3.zero, 2f * boundaryDistance);
        }
    }
}