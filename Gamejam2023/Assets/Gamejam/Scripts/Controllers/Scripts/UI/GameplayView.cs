using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Gamejam.Scripts.Controllers.Scripts.UI
{
    public class GameplayView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI collectionText;

        private int maxCount;

        private void OnEnable()
        {
            Time.timeScale = 1;
        }
        
        private void OnDisable()
        {
            Time.timeScale = 0;
        }

        public void Setup(int max)
        {
            maxCount = max;
            collectionText.text = $"COLLECTION: 0 : {maxCount}";
        }

        public void UpdateCount(int count)
        {
            collectionText.text = $"COLLECTION: {count} : {maxCount}";
            StartCoroutine(ClaimAnim());
        }

        private IEnumerator ClaimAnim()
        {
            float currentTime = 0;
            float time = 1;
            
            float currentScale = 1;
            float scale = 1.5f;

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

                collectionText.transform.localScale = Vector3.one * currentScale;
            }
            
            collectionText.transform.localScale = Vector3.one;
            
        }
    }
}