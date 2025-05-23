using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyDefense
{
    // PausedUI 관리하는 클래스
    public class PausedUI : MonoBehaviour
    {
        #region Field
        // 신 페이더
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        // UI 오브젝트
        public GameObject pausedUI;
        #endregion
        

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            pausedUI.SetActive(!pausedUI.activeSelf);

            // 창이 열리면
            if (pausedUI.activeSelf)
            {
                Time.timeScale = 0;
            }
            else // 창이 닫히면
            {
                Time.timeScale = 1;
            }
        }

        public void Retry()
        {
            Time.timeScale = 1f;

            // 해당(자기 자신) 신을 다시 부른다
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
            fader.FadeTo(SceneManager.GetActiveScene().name);   // 신 이름으로 로드
        }

        public void Menu()
        {
            Time.timeScale = 1f;

            fader.FadeTo(loadToScene);
        }
    }
}

