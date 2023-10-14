using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gamejam.Scripts.Controllers.Scripts.UI
{
    public class GameplayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI collectionText;
        [SerializeField] private Image orbImage;

        private int maxCount;

        private void OnEnable()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        private void OnDisable()
        {
            Time.timeScale = 0;
        }

        public void Setup(int max)
        {
            maxCount = max;
            collectionText.text = $"0 / {maxCount}";
        }

        public void UpdateCount(int count)
        {
            collectionText.text = $"{count} / {maxCount}";
            StartCoroutine(ClaimAnim());
        }

        private IEnumerator ClaimAnim()
        {
            float currentTime = 0;
            float time = 1;
            
            float currentScale = 1;
            float scale = 1.8f;

            var halfTime = time / 2;

            var startCurve = AnimationCurve.EaseInOut(0, 1, halfTime, scale);
            var endCurve = AnimationCurve.EaseInOut(0, scale, halfTime, 1);

            while (currentTime <= time)
            {
                yield return null;

                currentTime += Time.deltaTime;
                
                if (currentTime <= halfTime)
                {
                    currentScale = startCurve.Evaluate((currentTime / halfTime));
                }
                else
                {
                    currentScale = endCurve.Evaluate((currentTime / halfTime));
                }

                orbImage.transform.localScale = Vector3.one * currentScale;
            }
            
            orbImage.transform.localScale = Vector3.one;
            
        }
    }
}