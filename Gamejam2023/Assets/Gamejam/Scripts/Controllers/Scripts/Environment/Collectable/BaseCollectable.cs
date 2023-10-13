using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.Environment.Collectable
{
    [RequireComponent(typeof(Collider))]
    public class BaseCollectable : MonoBehaviour
    {
        [SerializeField] private CollectableTypes itemType;
        
        
    }
}