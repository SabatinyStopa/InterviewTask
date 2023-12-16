using InterviewTask.Enums;
using UnityEngine;

namespace InterviewTask.Items
{
    public class Item
    {
        public int Id;
        public CustomizableParts Part;
        public Color PartColor;
        public string Name;
        public string Value;
        public Sprite ImageSprite;
        public RuntimeAnimatorController Animator;

        public Item()
        {
        }

        public Item(Item item)
        {
            Part = item.Part;
            PartColor = item.PartColor;
            Name = item.Name;
            Value = item.Value;
            ImageSprite = item.ImageSprite;
            Animator = item.Animator;
            Id = item.Id;
        }
    }
}