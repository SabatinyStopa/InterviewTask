using InterviewTask.Enums;
using UnityEngine;

namespace InterviewTask.Scriptables
{
    [CreateAssetMenu(fileName = "ItemScriptable", menuName = "InterviewTask/Item Scriptable", order = 0)]
    public class ItemScriptable : ScriptableObject
    {
        public int Id;
        public CustomizableParts Part;
        public Color PartColor;
        public string Name;
        public string Value;
        public Sprite ImageSprite;
        public RuntimeAnimatorController Animator;
    }
}