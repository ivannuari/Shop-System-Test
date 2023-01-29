using Dev.Scripts;
using TMPro;
using UnityEngine;

namespace Dev.UI
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] protected Page[] pages;

        [SerializeField] TMP_Text label_coin;
        [SerializeField] TMP_Text label_diamond;

        protected virtual void Start()
        {
            SetPage(0);
        }

        public virtual void SetPage(int pageNumber)
        {
            foreach (var page in pages)
            {
                page.gameObject.SetActive(false);
            }
            pages[pageNumber].gameObject.SetActive(true);
        }

        protected void OnDiamondChange(int value)
        {
            label_diamond.text = value.ToString();
        }

        protected void OnCoinChange(int value)
        {
            label_coin.text = value.ToString();
        }
    }
}