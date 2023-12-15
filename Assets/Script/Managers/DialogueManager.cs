using System.Collections;
using UnityEngine;
using TMPro;

namespace InterviewTask.Managers
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance;
        [SerializeField] private TextMeshProUGUI dialogueText;

        private void Awake() => Instance = this;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                StopAllCoroutines();
                StartCoroutine(PlayDialogue("Hello there, my name is jonas. And i love to test things"));
            }
        }

        public IEnumerator PlayDialogue(string targetText)
        {
            dialogueText.text = string.Empty;
            dialogueText.enabled = true;
            var counter = 0;

            while (counter < targetText.Length)
            {
                yield return new WaitForSeconds(0.02f);
                dialogueText.text += targetText[counter];
                counter++;
            }

            yield return new WaitForSeconds(4f);
            dialogueText.enabled = false;
        }
    }
}