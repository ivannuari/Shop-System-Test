using Dev.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.UI
{
    public class CharacterSelectPage : Page
    {
        [SerializeField] Button b_all;
        [SerializeField] Button b_common;
        [SerializeField] Button b_rare;
        [SerializeField] Button b_epic;
        [SerializeField] Button b_legendary;

        private void Start()
        {
            b_all.onClick.AddListener(InitAll);
            b_common.onClick.AddListener(InitCommon);
            b_rare.onClick.AddListener(InitRare);
            b_epic.onClick.AddListener(InitEpic);
            b_legendary.onClick.AddListener(InitLegendary);

            InitAll();
        }

        private void InitAll()
        {
            ShopManager.Instance.ResetAll();

            InitData(CharacterTier.COMMON);
            InitData(CharacterTier.RARE);
            InitData(CharacterTier.EPIC);
            InitData(CharacterTier.LEGENDARY);
        }

        private void InitCommon()
        {
            ShopManager.Instance.ResetAll();
            InitData(CharacterTier.COMMON);
        }

        private void InitRare()
        {
            ShopManager.Instance.ResetAll();
            InitData(CharacterTier.RARE);
        }

        private void InitEpic()
        {
            ShopManager.Instance.ResetAll();
            InitData(CharacterTier.EPIC);
        }

        private void InitLegendary()
        {
            ShopManager.Instance.ResetAll();
            InitData(CharacterTier.LEGENDARY);
        }

        private void InitData(CharacterTier tier)
        {
            for (int i = 0; i < ShopManager.Instance.GetData(tier).Length; i++)
            {
                CharacterCard d = ShopManager.Instance.GetCard();
                d.gameObject.SetActive(true);
                d.SetData(ShopManager.Instance.GetData(tier)[i]);
            }
        }
    }
}
