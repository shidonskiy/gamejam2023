using System;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts
{
    public class GlobalGravity : GravitySource
    {
        [SerializeField] private float gravity;

        public override Vector3 GetGravity (Vector3 position, out bool isActive)
        {
            isActive = true;
            return transform.up * gravity;
        }
    }
}