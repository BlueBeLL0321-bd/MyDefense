using UnityEngine;
using System.Collections;
using TMPro;

namespace MyDefense
{
    // Enemy 스폰/웨이브를 관리하는 스크립트
    public class WaveManager : MonoBehaviour
    {
        #region Field
        // 현재 게임 화면에서 살아 있는 enemy 숫자
        public static int enemyAlive = 0;

        // 웨이브 데이터 세팅 : 적 프리팹, 생성할 개수, 생성 딜레이 타임
        public Wave[] waves; // waves[0~4]

        // 적 스폰 위치
        public Transform startPoint;

        // 타이머
        public float waveTimer = 5f;
        private float countdown = 0f;

        // 웨이브 카운트
        private int waveCount = 0;

        // UI Countdown Text
        // public TextMeshProUGUI countdownText;

        // 웨이브 스타트, 웨이브 정보, 적 개체 수
        public GameObject startButton;
        public GameObject waveInfo;

        public TextMeshProUGUI countText;
        private int enemyCount;             // 웨이브에서 생성할 개수

        // 게임 매니저
        public GameManager gameManager;
        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // 초기화
            countdown = 3f;
            waveCount = 0;
            enemyAlive = 0;
            enemyCount = 0;
        }

        // Update is called once per frame
        void Update()
        {

            // 현재 맵에 enemy가 있는지 여부 체크, 스폰, 카운트다운 막는다
            if (enemyAlive > 0)
            {
                // 현재 살아 있는 적의 개수 / 웨이브에서 생성할 개수
                countText.text = enemyAlive.ToString() + "/" + enemyCount.ToString();
                return;
            }
                
            // enemyAlive == 0
            // 레벨 클리어 체크
            if (waveCount >= waves.Length)
            {
                gameManager.LevelClear();
                this.enabled = false;       // WaveManager 클래스의 객체 기능 비활성화
                return;
            }

            // start UI 세팅
            if (waveInfo.activeSelf)
            {
                waveInfo.SetActive(false);
                startButton.SetActive(true);
            }


            /*// 타이머 구현
            countdown += Time.deltaTime;
            if(countdown >= waveTimer)
            {
                // 타이머 기능
                StartCoroutine(SpawnWave());

                // 타이머 초기화
                countdown = waveTimer;
            }

            // UI
            countdownText.text = Mathf.Round(countdown).ToString();*/
        }

        // 웨이브 생성
        IEnumerator SpawnWave()
        {
            // 적 프리팹, 생성할 개수, 생성 딜레이 타임
            Wave wave = waves[waveCount];

            enemyCount = wave.count;
            enemyAlive = wave.count;
            Debug.Log($"enemyAlive 생성 : {WaveManager.enemyAlive}");

            // 라운드 카운트
            PlayerStats.Rounds++;

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemyPrefab);

                // 일정 시간 지연
                yield return new WaitForSeconds(wave.delayTime);
            }

            waveCount++;
            
        }

        // 시작 지점에 enemy 스폰
        void SpawnEnemy(GameObject prefab)
        {
            Instantiate(prefab, startPoint.position, Quaternion.identity);
        }

        // 시작 버튼 클릭 시 호출
        public void WaveStart()
        {
            // UI
            startButton.SetActive(false);
            waveInfo.SetActive(true);

            Debug.Log("웨이브 시작");
            StartCoroutine(SpawnWave());
        }
    }
}
