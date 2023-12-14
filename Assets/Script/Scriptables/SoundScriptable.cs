using UnityEngine;
using UnityEngine.Audio;

namespace InterviewTask.Scriptables
{
    [CreateAssetMenu(fileName = "Sound", menuName = "OneBitJam/Sound", order = 0)]
    public class SoundScriptable : ScriptableObject
    {
        public string Id;
        public AudioClip AudioClip;
        public AudioMixerGroup AudioMixer;
        public bool Loop;
    }
}