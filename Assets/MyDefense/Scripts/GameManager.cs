using UnityEngine;

namespace MyDefense
{
    // 게임의 전체 흐름을 관리하는 클래스
    public class GameManager : MonoBehaviour
    {
        #region Field
        // 치트 체크
        [SerializeField] private bool isCheat = false;

        // 게임 오버
        // UI
        public GameObject GameOverUI;

        public GameObject PausedUI;

        private static bool isGameOver = false;
        #endregion

        #region Property
        public static bool IsGameOver
        {
            get { return isGameOver; }
        }
        #endregion

        private void Start()
        {
            // 초기화
            isGameOver = false;
        }

        private void Update()
        {
            
            if (IsGameOver)
                return;

            // 게임 오버되었는지 체크
            if(PlayerStats.Lives <= 0)
            {
                ShowGameOverUI();
            }

            // Cheating
            if (Input.GetKeyDown(KeyCode.M))
            {
                ShowMeTheMoney();
            }

            if (Input.GetKeyDown(KeyCode.O) && isCheat == true)
            {
                ShowGameOverUI();
            }
        }

        // 게임 오버 UI 보여 주기
        void ShowGameOverUI()
        {
            isGameOver = true;
            GameOverUI.SetActive(true);
        }


        // Cheating
        // M키를 누르면 10만 골드 지급
        void ShowMeTheMoney()
        {
            if (isCheat == false)
                return;

            PlayerStats.AddMoney(100000);
        }

        // 레벨 업 치팅
        void LevelUpCheat()
        {
            if (isCheat == false)
                return;

            // PlayerStats.LevelUp();
        }

    }
}