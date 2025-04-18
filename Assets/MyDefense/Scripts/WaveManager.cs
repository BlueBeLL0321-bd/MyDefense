using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefense
{
    public class WaveManager : MonoBehaviour
    {
        #region Field
        // 적 프리팹
        public GameObject enemyPrefab;
        // 적 스폰 위치
        public Transform startPoint;

        // 타이머
        public float waveTimer = 5f;
        private float countdown = 0f;

        // 웨이브 카운트
        private int waveCount = 0;

        // UI Countdown Text
        public TextMeshProUGUI countdownText;
        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // 초기화
            countdown = 0f;
            waveCount = 0;
        }

        // Update is called once per frame
        void Update()
        {
            // 게임 오버 체크


            // 타이머 구현
            countdown += Time.deltaTime;
            if(countdown >= waveTimer)
            {
                // 타이머 기능
                StartCoroutine(SpawnWave());

                // 타이머 초기화
                countdown = 0f;
            }

            // UI
            countdownText.text = Mathf.Round(countdown).ToString();
        }

        // 웨이브
        IEnumerator SpawnWave()
        {
            waveCount++;

            // 라운드 카운트
            PlayerStats.Rounds++;

            for (int i = 0; i < waveCount; i++)
            {
                SpawnEnemy();

                // 일정 시간 지연
                yield return new WaitForSeconds(0.5f);
            }
        }

        // 시작 지점에 enemy 스폰
        void SpawnEnemy()
        {
            Instantiate(enemyPrefab, startPoint.position, Quaternion.identity);
        }
    }
}
