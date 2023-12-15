using System.Collections;
using UnityEngine;
using System;
using TMPro;

namespace InterviewTask.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private string[] charSoundId;

        private void Awake() => Instance = this;

        public void PlayDialogue(string targetText, float timeAfterDialogue = 4, Action stopInteract = null)
        {
            StopAllCoroutines();
            StartCoroutine(StartDialogue(targetText, timeAfterDialogue, stopInteract));
        }

        private IEnumerator StartDialogue(string targetText, float timeAfterDialogue = 4, Action stopInteract = null)
        {
            dialogueText.text = string.Empty;
            dialogueText.enabled = true;
            var counter = 0;

            while (counter < targetText.Length)
            {
                yield return new WaitForSeconds(0.02f);
                dialogueText.text += targetText[counter];
                counter++;
                SoundManager.Instance.PlaySound(charSoundId[UnityEngine.Random.Range(0, charSoundId.Length - 1)]);
            }

            yield return new WaitForSeconds(timeAfterDialogue);
            dialogueText.enabled = false;
            stopInteract?.Invoke();
        }
    }
}