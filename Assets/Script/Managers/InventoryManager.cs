using System.Collections.Generic;
using InterviewTask.Equipables;

namespace InterviewTask.Managers
{
    public class InventoryManager : CharacterCustomization
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            var newItem = new Item(item);
            var itemUi = Instantiate(itemUIPrefab, contentParent);

            items.Add(newItem);
            itemUi.SetItem(newItem, this);
        }
    }
}