using UnityEngine;
using UnityEngine.UI;

namespace Gamejam.Scripts.Controllers.Scripts.UI
{
    public class CompleteView : MonoBehaviour
    {
        [SerializeField] private Button replay;
        [SerializeField] private Button next;

        private void Awake()
        {
            replay.onClick.AddListener(Replay);
            next.onClick.AddListener(Next);
        }

        private void Replay()
        {
            Game.Instance.RestartLevel();
        }

        private void Next()
        {
            Game.Instance.StartNextLevel();
        }
    }
}