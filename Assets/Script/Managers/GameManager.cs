using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace InterviewTask.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;

        private IEnumerator Start()
        {
            fadeImage.enabled = true;
            SoundManager.Instance.PlaySound("Music");

            var amount = 1f;

            while (amount > 0)
            {
                yield return new WaitForSeconds(0.01f);
                fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, amount);
                amount -= 0.01f;
            }

            fadeImage.enabled = false;
        }
    }
}