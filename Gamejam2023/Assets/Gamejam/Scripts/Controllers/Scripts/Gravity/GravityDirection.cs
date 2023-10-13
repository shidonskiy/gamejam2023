using UnityEditor;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts
{
    public class GravityDirection : GravitySource
    {
        [SerializeField]
        float gravity = 9.81f;

        [SerializeField]
        public Bounds boundaryDistance = new Bounds(Vector3.zero, Vector3.one);

        public override Vector3 GetGravity(Vector3 position)
        {
            var localPos = transform.InverseTransformPoint(position);
            
            if (boundaryDistance.Contains(localPos))
            {
                return transform.up * gravity;
            }

            return Vector3.zero;
        }

        void OnDrawGizmos () {
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(boundaryDistance.center, boundaryDistance.size);
        }
    }
}