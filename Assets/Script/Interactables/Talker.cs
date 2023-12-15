using InterviewTask.Managers;
using UnityEngine;

namespace InterviewTask.Interactables
{
    public class Talker : Interactable
    {
        [SerializeField] private string[] text = { "Hello there!" };
        [SerializeField] private float timeAfterDialogue = 2f;

        protected override void Interact()
        {
            base.Interact();
            DialogueManager.Instance.PlayDialogue(text[Random.Range(0, text.Length - 1)], timeAfterDialogue, StopInteract);
        }
    }
}