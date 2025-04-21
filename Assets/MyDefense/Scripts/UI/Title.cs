using UnityEngine;
using System.Collections;

namespace MyDefense
{
    public class Title : MonoBehaviour
    {
        #region Field
        public SceneFader fader;

        // 다음으로 이동하는 신 이름
        [SerializeField]
        private string loadToScene = "MainMenu";

        // AnyKey UI 오브젝트
        public GameObject anyKey;

        // AnyKey UI를 보여 주고 있는지 체크
        private bool isShow = false;

        // 타이머
        [SerializeField]
        private float titleTimer = 3f;
        private float countdown = 0f;

        [SerializeField]
        private float spawnDelay = 2f;  // 생성 딜레이 2초
        private float spawnTime;    // 몬스터 생성한 시간 저장

        private bool isOneTime = false; // 실행 안 했으면 false, 한 번이라도 실행했으면 true
        #endregion

        private void Start()
        {
            // 초기화
            // countdown = 0f;
            // countdown = titleTimer;
            // spawnTime = Time.time; // 현재 시간 저장
            isShow = false;

            // InvokeRepeating 처음 시작 시 1초 딜레이 후 2초 간격으로 몬스터 생성
            // InvokeRepeating("SpawnMonster", 1f, 2f);

            // 지연 - Invoke
            // Invoke("SpawnMonster", spawnDelay);

            // 지연 - Coroutine
            // StartCoroutine(Spawn());

            StartCoroutine(titleProcess());
        }

        private void Update()
        {
            /*// Time.deltaTime 더하기 누적 반복 타이머
            countdown += Time.deltaTime;
            if(countdown >= titleTimer)
            {
                // 반복 실행문
                GoToMenu();

                // 타이머 초기화
                countdown = 0f;
            }*/

            /*// Time.deltaTime 빼기 누적 반복 타이머
            countdown -= Time.deltaTime;
            if(countdown <= 0f)
            {
                // 반복 실행문
                GoToMenu();

                // 타이머 초기화
                countdown = titleTimer;
            }*/

            /*// Time.time 현재 시간을 저장하고 현재 시간이 딜레이 시간만큼 지났는지 체크
            if((spawnTime + spawnDelay) <= Time.time)
            {
                // 반복 실행문
                SpawnMonster();
                
                // 타이머 초기화 - 현재 시간을 다시 저장
                spawnTime = Time.time;
            }*/

            /*// Time.deltaTime 더하기 누적 반복 타이머 - 1회 실행
            if(isOneTime == false)
            {
                countdown += Time.deltaTime;
                if (countdown >= titleTimer)
                {
                    // 반복 실행문
                    GoToMenu();

                    // 타이머 초기화
                    countdown = 0f;
                    isOneTime = true;
                }
            }*/

            // 아무 키를 누르면 메인 메뉴 신으로 이동
            if (Input.anyKeyDown && isShow)
            {
                // 현재 대기하고 있는 모든 코루틴 함수 정지
                StopAllCoroutines();

                GoToMenu();
            }
        }

        IEnumerator titleProcess()
        {
            yield return new WaitForSeconds(titleTimer);
            ShowAnyKey();

            yield return new WaitForSeconds(10);
            GoToMenu();
        }

        private void ShowAnyKey()
        {
            isShow = true;
            anyKey.SetActive(true);
        }

        private void GoToMenu()
        {
            fader.FadeTo(loadToScene);
        }

        private void SpawnMonster()
        {
            Debug.Log("Spawn Monster");
        }

        IEnumerator Spawn()
        {
            // spawnDelay 만큼 딜레이
            yield return new WaitForSeconds(spawnDelay);
            SpawnMonster();
        }
    }
}

/*
타이머
- 1회성 - 반복 실행 중 1회 실행하고 더 이상 반복하지 않는다

- 반복
- 2초마다 메인 메뉴 보내기
*/
