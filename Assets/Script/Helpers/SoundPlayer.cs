using InterviewTask.Managers;
using UnityEngine;

namespace InterviewTask.Helpers
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private string[] soundsToPlay;

        public void PlayRandomSound() => SoundManager.Instance.PlaySound(soundsToPlay[Random.Range(0, soundsToPlay.Length - 1)]);
    }
}