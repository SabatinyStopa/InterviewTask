using InterviewTask.Managers;
using UnityEngine;

namespace InterviewTask.Interactables
{
    public class Mage : Interactable
    {
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private string[] phrases;
        [SerializeField] private float amountToAdd = 300f;

        protected override void Interact()
        {
            base.Interact();
            inventoryManager.AddCurrentAmount(amountToAdd);
            DialogueManager.Instance.PlayDialogue(phrases[Random.Range(0, phrases.Length - 1)], 2f, StopInteract);
            SoundManager.Instance.PlaySound("Cash");
        }
    }
}