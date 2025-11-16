using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

namespace TapTap
{
    public class AdManager : MonoBehaviour
    {
        public static AdManager Instance { get; private set; }

        [SerializeField]
        private int m_DeathsBeforeAd = 3;

        private int m_DeathCount = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void RecordDeath()
        {
            m_DeathCount++;

            if (m_DeathCount >= m_DeathsBeforeAd)
            {
                m_DeathCount = 0;
                ShowAd();
            }
        }

        public void ShowAd()
        {
#if UNITY_ADS
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
            }
            else
            {
                Debug.Log("AdManager: Unity Ads not ready yet.");
            }
#else
            Debug.Log("AdManager.ShowAd called (UNITY_ADS not defined). Configure Unity Ads to enable real ads.");
#endif
        }
    }
}
