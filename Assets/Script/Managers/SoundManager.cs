using UnityEngine;
using InterviewTask.Scriptables;

namespace InterviewTask.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [SerializeField] private SoundScriptable[] allScriptables;

        private void Awake() => Instance = this;

        public void PlaySound(string id)
        {
            foreach (SoundScriptable soundScriptable in allScriptables)
            {
                if (soundScriptable.Id == id)
                {
                    Play(id, soundScriptable);
                    break;
                }
            }
        }

        private void Play(string id, SoundScriptable soundScriptable)
        {
            var sound = new GameObject("Sound-" + id).AddComponent<AudioSource>();

            sound.clip = soundScriptable.AudioClip;
            sound.playOnAwake = false;
            sound.loop = soundScriptable.Loop;
            sound.outputAudioMixerGroup = soundScriptable.AudioMixer;

            sound.Play();

            Destroy(sound.gameObject, soundScriptable.AudioClip.length + 0.01f);
        }
    }
}