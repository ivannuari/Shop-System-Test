using UnityEngine;

namespace Dev.Scripts
{
    [CreateAssetMenu(fileName = "new Chara")]
    public class CharacterData : ScriptableObject
    {
        public string nama;
        public CharacterTier tier;
        public Sprite Icon;
        
        public bool isUnlocked;
        public bool isCurrentlyUse;
    }
}