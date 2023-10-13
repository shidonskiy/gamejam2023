using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts
{
    public class GlobalGravity : GravitySource
    {
        [SerializeField] private Vector3 gravity;
        
        public override Vector3 GetGravity (Vector3 position) {
            return gravity;
        }
    }
}