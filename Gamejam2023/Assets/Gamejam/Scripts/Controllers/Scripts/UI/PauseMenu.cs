using UnityEngine;
using UnityEngine.UI;

namespace Gamejam.Scripts.Controllers.Scripts.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button backToMainscreen;
        [SerializeField] private Button replay;
        [SerializeField] private Button back;

        private void Awake()
        {
            backToMainscreen.onClick.AddListener(BackToMainscreen);
            replay.onClick.AddListener(Replay);
            back.onClick.AddListener(Back);
        }

        private void BackToMainscreen()
        {
            Game.Instance.GoToMainscreen();
        }

        private void Replay()
        {
            Game.Instance.RestartLevel();
        }

        private void Back()
        {
            Game.Instance.GoToGameplay();
        }
    }
}