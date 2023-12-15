using InterviewTask.Enums;
using UnityEditor.Animations;
using UnityEngine;

namespace InterviewTask.Equipables
{
    public class Item
    {
        public CustomizableParts Part;
        public Color PartColor;
        public string Name;
        public string Value;
        public Sprite ImageSprite;
        public AnimatorController Animator;

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
        }
    }
}