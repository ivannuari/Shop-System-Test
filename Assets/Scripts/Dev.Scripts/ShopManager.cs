using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.Scripts
{
    public class ShopManager : MonoBehaviour
    {
        public static ShopManager Instance;

        [SerializeField] private CharacterData[] datas;

        [SerializeField] private CharacterCard card;
        [SerializeField] private Transform cardContent;

        private List<CharacterCard> cards = new List<CharacterCard>();

        private void Awake()
        {
            if (Instance != null)
            {
                return;
            }
            Instance = this;

            for (int i = 0; i < datas.Length; i++)
            {
                CharacterCard c = Instantiate(card, transform.position, Quaternion.identity);
                c.transform.SetParent(cardContent);
                cards.Add(c);
                c.gameObject.SetActive(false);
            }
        }

        public CharacterCard GetCard()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (!cards[i].gameObject.activeInHierarchy)
                {
                    return cards[i];
                }
            }
            return null;
        }

        public CharacterData[] GetData(CharacterTier tier)
        {
            CharacterData[] d = Array.FindAll(datas, dt => dt.tier == tier);
            return d;
        }

        public void ResetAll()
        {
            foreach (Transform t in cardContent)
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}
