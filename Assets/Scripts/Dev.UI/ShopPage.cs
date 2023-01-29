using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dev.Scripts;
using System;
using TMPro;

namespace Dev.UI
{
    public class ShopPage : Page
    {
        [SerializeField] Button b_gachaCommon;
        [SerializeField] Button b_gachaRare;
        [SerializeField] Button b_gachaEpic;
        [SerializeField] Button b_gachaLegendary;

        [SerializeField] private int commonRequirment;
        [SerializeField] private int rareRequirment;
        [SerializeField] private int epicRequirment;
        [SerializeField] private int legendaryRequirment;

        [SerializeField] TMP_Text label_info;

        private void Start()
        {
            b_gachaCommon.onClick.AddListener(() => HandleGachaButton(CharacterTier.COMMON));
            b_gachaRare.onClick.AddListener(() => HandleGachaButton(CharacterTier.RARE));
            b_gachaEpic.onClick.AddListener(() => HandleGachaButton(CharacterTier.EPIC));
            b_gachaLegendary.onClick.AddListener(() => HandleGachaButton(CharacterTier.LEGENDARY));
        }

        private void HandleGachaButton(CharacterTier tier)
        {
            switch (tier)
            {
                case CharacterTier.COMMON:
                    if(GameManager.Instance.GetCoin() >= commonRequirment)
                    {
                        GameManager.Instance.ChangeCoin(-commonRequirment);
                    }
                    else
                    {
                        StartCoroutine(SetInfo("Not Enough Coin!"));
                        return;
                    }
                    break;
                case CharacterTier.RARE:
                    if(GameManager.Instance.GetDiamond() >= rareRequirment)
                    {
                        GameManager.Instance.ChangeDiamond(-rareRequirment);
                    }
                    else
                    {
                        StartCoroutine(SetInfo("Not Enough Diamond!"));
                        return;
                    }
                    break;
                case CharacterTier.EPIC:
                    if (GameManager.Instance.GetDiamond() >= epicRequirment)
                    {
                        GameManager.Instance.ChangeDiamond(-epicRequirment);
                    }
                    else
                    {
                        StartCoroutine(SetInfo("Not Enough Diamond!"));
                        return;
                    }
                    break;
                case CharacterTier.LEGENDARY:
                    if (GameManager.Instance.GetDiamond() >= legendaryRequirment)
                    {
                        GameManager.Instance.ChangeDiamond(-legendaryRequirment);
                    }
                    else
                    {
                        StartCoroutine(SetInfo("Not Enough Diamond!"));
                        return;
                    }
                    break;
            }

            GameManager.Instance.gachaType = tier;
            ChangeScene("LuckySpin");
        }

        IEnumerator SetInfo(string info)
        {
            label_info.gameObject.SetActive(true);
            label_info.text = info;

            yield return new WaitForSeconds(1f);
            label_info.gameObject.SetActive(false);
        }
    }
}
