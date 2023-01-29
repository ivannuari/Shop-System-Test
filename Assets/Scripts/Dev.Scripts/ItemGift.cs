using UnityEngine;

namespace Dev.Scripts
{
    [CreateAssetMenu(fileName = "new item hadiah")]
    public class ItemGift : ScriptableObject
    {
        public Sprite icon;
        public GiftType type;

        [Header("If Gift coin / diamond input value here:")]
        public int amount;

        [Header("If Gift character input value here:")]
        public CharacterData character;
    }
}