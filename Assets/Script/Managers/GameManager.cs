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
            SoundManager.Instance.PlaySound("Music");
            yield return null;
        }
    }
}