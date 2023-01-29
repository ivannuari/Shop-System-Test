using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Dev.Scripts
{
    public class ItemWheel : MonoBehaviour
    {
        public int initValue;

        [SerializeField] private ItemGift data;
        [SerializeField] private Image iconValueable;
        [SerializeField] private Image iconCharacter;
        [SerializeField] private TMP_Text label_value;

        public void SetData(ItemGift newData)
        {
            data = newData;
            InitializeData();
        }

        private void InitializeData()
        {
            switch (data.type)
            {
                case GiftType.CHARACTER:
                    label_value.gameObject.SetActive(false);
                    iconValueable.gameObject.SetActive(false);
                    iconCharacter.gameObject.SetActive(true);

                    iconCharacter.sprite = data.icon;
                    break;
                case GiftType.COIN:
                    label_value.gameObject.SetActive(true);
                    iconValueable.gameObject.SetActive(true);
                    iconCharacter.gameObject.SetActive(false);

                    label_value.text = data.amount.ToString();
                    iconValueable.sprite = data.icon;
                    break;
                case GiftType.DIAMOND:
                    label_value.gameObject.SetActive(true);
                    iconValueable.gameObject.SetActive(true);
                    iconCharacter.gameObject.SetActive(false);

                    label_value.text = data.amount.ToString();
                    iconValueable.sprite = data.icon;
                    break;
            }
        }
    }
}