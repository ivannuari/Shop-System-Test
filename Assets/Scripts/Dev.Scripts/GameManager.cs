using System.Collections.Generic;
using UnityEngine;

namespace Dev.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Selected Character data: ")]
        [SerializeField] CharacterData currentCharacterData;

        [SerializeField] int coin;
        [SerializeField] int diamond;

        public CharacterTier gachaType;

        public delegate void CoinChangeDelegate(int value);
        public CoinChangeDelegate OnCoinChange;

        public delegate void DiamondChangeDelegate(int value);
        public DiamondChangeDelegate OnDiamondChange;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public int GetCoin()
        {
            return coin;
        }

        public int GetDiamond()
        {
            return diamond;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                int n = Random.Range(250, 750); ;
                coin += n;
                OnCoinChange?.Invoke(coin);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                int n = Random.Range(10, 50);
                diamond += n;
                OnDiamondChange?.Invoke(diamond);
            }
        }

        public void ChangeCoin(int amount)
        {
            coin += amount;
            OnCoinChange?.Invoke(coin);
        }

        public void ChangeDiamond(int amount)
        {
            diamond += amount;
            OnDiamondChange?.Invoke(diamond);
        }

        public void CheckValueAmount()
        {
            OnCoinChange?.Invoke(coin);
            OnDiamondChange?.Invoke(diamond);
        }

        public void SetNewCharacterSelected(CharacterData newData)
        {
            currentCharacterData.isCurrentlyUse = false;

            currentCharacterData = newData;
            currentCharacterData.isCurrentlyUse = true;
        }
    }
}
