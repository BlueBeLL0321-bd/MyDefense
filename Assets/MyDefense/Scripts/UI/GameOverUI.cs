using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.UI;

namespace MyDefense
{
    public class GameOverUI : MonoBehaviour
    {
        #region Field
        // 신 페이더
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        public TextMeshProUGUI roundText;
        #endregion

        // 활성화 시 한 번만 호출하고 값을 초기화한다
        private void OnEnable()
        {
            roundText.text = PlayerStats.Rounds.ToString();
        }

        // 다시 하기 버튼 클릭 시 호출
        public void Retry()
        {
            // 게임 초기화
            // GameManager.IsGameOver = false;
            // ...

            Debug.Log("Retry Game!!!");
            // 해당(자기 자신) 신을 다시 부른다
            fader.FadeTo(SceneManager.GetActiveScene().name);    // 신 이름으로 로드

            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // 빌드 인덱스로 로드
        }

        // 메뉴 버튼 클릭 시 호출
        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}