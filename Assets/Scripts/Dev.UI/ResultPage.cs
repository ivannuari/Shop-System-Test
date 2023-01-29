using Dev.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.UI
{
    public class ResultPage : Page
    {
        [SerializeField] Button b_back;

        [SerializeField] Image icon_character;
        [SerializeField] Image icon_valueable;
        [SerializeField] TMP_Text label_value;

        [SerializeField] TMP_Text label_result;

        private void Start()
        {
            b_back.onClick.AddListener(() => ChangeScene("Shop"));
        }

        public void SetPrizes(ItemGift gift)
        {
            switch (gift.type)
            {
                case GiftType.CHARACTER:
                    icon_character.gameObject.SetActive(true);
                    icon_valueable.gameObject.SetActive(false);
                    label_value.gameObject.SetActive(false);

                    icon_character.sprite = gift.icon;
                    label_result.text = "NEW CHARACTER !!";
                    break;
                case GiftType.COIN:
                    icon_character.gameObject.SetActive(false);
                    icon_valueable.gameObject.SetActive(true);
                    label_value.gameObject.SetActive(true);

                    icon_valueable.sprite = gift.icon;
                    label_value.text = gift.amount.ToString();
                    label_result.text = $"{gift.amount} COIN !!";
                    break;
                case GiftType.DIAMOND:
                    icon_character.gameObject.SetActive(false);
                    icon_valueable.gameObject.SetActive(true);
                    label_value.gameObject.SetActive(true);

                    icon_valueable.sprite = gift.icon;
                    label_value.text = gift.amount.ToString();
                    label_result.text = $"{gift.amount} DIAMOND !!";
                    break;
            }
        }
    }

}