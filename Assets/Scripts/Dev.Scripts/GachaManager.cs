using Dev.UI;
using System;
using System.Collections;
using UnityEngine;

namespace Dev.Scripts
{
    public class GachaManager : MonoBehaviour
    {
        public static GachaManager Instance;

        [SerializeField] private ItemGift[] giftContainers;
        [SerializeField] private ItemGift[] giftCharactersContainers;

        private void Awake()
        {
            if(Instance != null)
            {
                return;
            }
            Instance = this;
        }

        public ItemGift[] GetArrayOfGift(GiftType type)
        {
            ItemGift[] newGifts = Array.FindAll(giftContainers , g => g.type == type);
            return newGifts;
        }

        public ItemGift[] GetArrayOfCharacter(CharacterTier tier)
        {
            ItemGift[] newGifts = Array.FindAll(giftCharactersContainers, g => g.character.tier == tier);
            ItemGift[] avalilableGifts = Array.FindAll(newGifts, g => !g.character.isUnlocked);
            return avalilableGifts;
        }
    }
}