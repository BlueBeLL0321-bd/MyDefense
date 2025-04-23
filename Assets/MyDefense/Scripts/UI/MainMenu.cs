using UnityEngine;

namespace MyDefense
{
    // 메인 메뉴 신을 관리하는 클래스
    public class MainMenu : MonoBehaviour
    {
        #region Field
        // 신 페이더
        public SceneFader fader;

        [SerializeField]
        private string loadToScene = "PlayScene";
        #endregion
        // 플레이 버튼 클릭하면 호출되는 함수
        public void Play()
        {
            fader.FadeTo(loadToScene);
        }

        // 게임 종료 버튼 클릭하면 호출되는 함수(어플리케이션 종료)
        public void Quit()
        {
            // Cheating
            PlayerPrefs.DeleteAll();

            // Unity 에디터에서 명령 무시, 빌드 버전에서는 구동
            Application.Quit();
        }
    }
}