using UnityEngine;
using UnityEngine.UI;

namespace MyDefense
{
    public class ClearUI : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        [SerializeField] private string loadToNext = "LevelSelect";
        #endregion

        // 컨티뉴 버튼 클릭 시 호출 - 레벨 셀렉트 신으로 이동
        public void Continue()
        {
            fader.FadeTo(loadToNext);
        }

        // 메뉴 버튼 클릭 시 호출 - 메인 메뉴 신으로 이동
        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}