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
    }
}