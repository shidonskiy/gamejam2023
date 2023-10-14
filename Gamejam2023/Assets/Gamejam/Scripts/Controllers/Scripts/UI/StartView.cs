using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gamejam.Scripts.Controllers.Scripts.UI
{
    public class StartView : MonoBehaviour
    {
        [SerializeField] private Button level1;
        [SerializeField] private Button level2;


        public void Awake()
        {
            level1.onClick.AddListener(() => StartLevel(1));
            level2.onClick.AddListener(() => StartLevel(2));
        }
        
        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        private void StartLevel(int index)
        {
            Game.Instance.StartLevel(index);
            Game.Instance.UpdateCurrentLevel(index);
        }
    }
}