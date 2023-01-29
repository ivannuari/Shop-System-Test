using Dev.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.UI
{
    public class ShopCanvasSetting : CanvasManager
    {
        [SerializeField] Button b_ShopPage;
        [SerializeField] Button b_CharacterPage;

        protected override void Start()
        {
            base.Start();
            b_ShopPage.onClick.AddListener(HandleShopPage);
            b_CharacterPage.onClick.AddListener(HandleCharacterPage);

            GameManager.Instance.OnCoinChange += OnCoinChange;
            GameManager.Instance.OnDiamondChange += OnDiamondChange;

            GameManager.Instance.CheckValueAmount();
        }

        private void OnDisable()
        {
            GameManager.Instance.OnCoinChange -= OnCoinChange;
            GameManager.Instance.OnDiamondChange -= OnDiamondChange;
        }

        private void HandleShopPage()
        {
            SetPage(0);
        }

        private void HandleCharacterPage()
        {
            SetPage(1);
        }
    }
}
