using Dev.Scripts;
using System.Collections;
using UnityEngine;

namespace Dev.UI
{
    public class GachaCanvasSetting : CanvasManager
    {
        private Wheels wheel;

        protected override void Start()
        {
            base.Start();

            GameManager.Instance.OnCoinChange += OnCoinChange;
            GameManager.Instance.OnDiamondChange += OnDiamondChange;

            wheel = GetComponentInChildren<Wheels>();
            wheel.OnStopSpin += Wheel_OnStopSpin;

            GameManager.Instance.CheckValueAmount();
        }

        private void OnDisable()
        {
            wheel.OnStopSpin -= Wheel_OnStopSpin;
            GameManager.Instance.OnCoinChange -= OnCoinChange;
            GameManager.Instance.OnDiamondChange -= OnDiamondChange;
        }

        private void Wheel_OnStopSpin(int v)
        {
            StartCoroutine(CheckPrizes(v));
        }

        IEnumerator CheckPrizes(int v)
        {
            //check prizes here
            ItemGift g = wheel.GetItemGiftValue(v);

            switch (g.type)
            {
                case GiftType.CHARACTER:
                    g.character.isUnlocked = true;
                    break;
                case GiftType.COIN:
                    GameManager.Instance.ChangeCoin(g.amount);
                    break;
                case GiftType.DIAMOND:
                    GameManager.Instance.ChangeDiamond(g.amount);
                    break;
            }

            yield return new WaitForSeconds(1.5f);
            SetPage(1);
            pages[1].GetComponent<ResultPage>().SetPrizes(g);
        }
    }
}