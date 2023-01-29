using Dev.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.Scripts
{
    public class CharacterCard : MonoBehaviour
    {
        [SerializeField] CharacterData data;

        [SerializeField] private TMP_Text label_tier;
        [SerializeField] private Image imageIcon;

        [SerializeField] Button b_use;
        [SerializeField] private TMP_Text label_button;

        private void Start()
        {
            b_use.onClick.AddListener(() =>
            {
                GameManager.Instance.SetNewCharacterSelected(data);
                label_button.text = label_button.text = "Selected";
            });
            transform.localScale = Vector3.one;
        }

        public void SetData(CharacterData newData)
        {
            data = newData;
            Initialize();
        }

        private void Initialize()
        {
            switch (data.tier)
            {
                case CharacterTier.COMMON:
                    label_tier.text = "COMMON";
                    break;
                case CharacterTier.RARE:
                    label_tier.text = "RARE";
                    break;
                case CharacterTier.EPIC:
                    label_tier.text = "EPIC";
                    break;
                case CharacterTier.LEGENDARY:
                    label_tier.text = "LEGENDARY";
                    break;
            }

            imageIcon.sprite = data.Icon;
            b_use.interactable = data.isUnlocked;

            if(data.isCurrentlyUse)
            {
                label_button.text = "Selected";
            }
            else
            {
                label_button.text = "Use";
            }
        }
    }
}
