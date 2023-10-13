using System;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts
{
    public class GlobalGravity : GravitySource
    {
        [SerializeField] private float gravity;

        public override Vector3 GetGravity (Vector3 position) {
            return transform.up * gravity;
        }
    }
}