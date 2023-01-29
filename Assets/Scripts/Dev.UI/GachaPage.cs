using Dev.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.UI
{
    public class GachaPage : Page
    {
        [SerializeField] private Button b_spin;
        
        [SerializeField] private List<ItemGift> itemGifts = new List<ItemGift>();

        private Wheels thisWheel;
        private CanvasManager canvasManager;

        private void Start()
        {
            thisWheel = GetComponentInChildren<Wheels>();
            canvasManager = GetComponentInParent<CanvasManager>();

            b_spin.onClick.AddListener(() =>
            { 
                thisWheel.StartSpin();
                b_spin.interactable = false;
            });

            GetItems();

            thisWheel.OnStopSpin += ThisWheel_OnStopSpin;
        }

        private void OnDisable()
        {
            thisWheel.OnStopSpin -= ThisWheel_OnStopSpin;
        }

        private void ThisWheel_OnStopSpin(int v)
        {
            b_spin.interactable = true;
        }

        private void GetItems()
        {
            List<ItemGift> randomGift = new List<ItemGift>();

            for (int i = 0; i < GachaManager.Instance.GetArrayOfGift(GiftType.COIN).Length; i++)
            {
                itemGifts.Add(GachaManager.Instance.GetArrayOfGift(GiftType.COIN)[i]);
            }

            for (int i = 0; i < GachaManager.Instance.GetArrayOfGift(GiftType.DIAMOND).Length; i++)
            {
                itemGifts.Add(GachaManager.Instance.GetArrayOfGift(GiftType.DIAMOND)[i]);
            }

            for (int i = 0; i < GachaManager.Instance.GetArrayOfCharacter(GameManager.Instance.gachaType).Length; i++)
            {
                randomGift.Add(GachaManager.Instance.GetArrayOfCharacter(GameManager.Instance.gachaType)[i]);
            }

            if(randomGift.Count < 12)
            {
                int n = 12 - randomGift.Count;

                for (int i = 0; i < n; i++)
                {
                    int r = Random.Range(0, itemGifts.Count);
                    randomGift.Add(itemGifts[r]);
                }
            }
            thisWheel.SetListOfGift(randomGift);
        }
    }
}