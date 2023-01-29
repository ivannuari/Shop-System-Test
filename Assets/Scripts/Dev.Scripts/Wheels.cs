using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dev.Scripts
{
    public class Wheels : MonoBehaviour
    {
        [SerializeField] private List<ItemGift> gifts = new List<ItemGift>();
        private List<ItemWheel> itemWheels = new List<ItemWheel>();

        public delegate void StartSpinDelegate();
        public event StartSpinDelegate OnStartSpin;

        public delegate void StopSpinDelegate(int value);
        public event StopSpinDelegate OnStopSpin;

        private void Start()
        {
            foreach (ItemWheel item in GetComponentsInChildren<ItemWheel>())
            {
                itemWheels.Add(item);
            }
        }

        public void StartSpin()
        {
            StartCoroutine(Spinning());
        }

        IEnumerator Spinning()
        {
            OnStartSpin?.Invoke();
            for (int i = 0; i < Random.Range(150 , 300); i++)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, i * 15f);
                yield return new WaitForSeconds(0.001f);
            }

            float v = Mathf.RoundToInt(transform.localEulerAngles.z);

            if (v == 0f || v == 30f || v == 60f || v == 90f || v == 120f || v == 150f ||
                v == 180f || v == 210f || v == 240f || v == 270f || v == 300f || v == 330f)
            {
                OnStopSpin?.Invoke((int)v);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, transform.localEulerAngles.z + 15f);
                v = Mathf.RoundToInt(transform.localEulerAngles.z);

                OnStopSpin?.Invoke((int)v);
            }
        }

        public void SetListOfGift(List<ItemGift> newGifts)
        {
            gifts = newGifts.OrderBy(x => Random.value).ToList();

            for (int i = 0; i < gifts.Count; i++)
            {
                itemWheels[i].SetData(gifts[i]);
            }
        }

        public ItemGift GetItemGiftValue(int v)
        {
            for (int i = 0; i < itemWheels.Count; i++)
            {
                if (itemWheels[i].initValue == v)
                {
                    return gifts[i];
                }
            }
            return null;
        }
    }
}