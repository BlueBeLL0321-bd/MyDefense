using UnityEngine;
using UnityEngine.UI;

namespace MyDefense
{
    public class LevelSelect : MonoBehaviour
    {
        #region Field
        public SceneFader fader;
        [SerializeField]
        private string loadToScene = "MainMenu";

        // 레벨 선택 버튼
        public Transform contents;  // 레벨 선택 버튼들의 부모 오브젝트
        private Button[] levelButtons;
        #endregion

        private void Start()
        {
            // 게임 실행 시 처음으로 저장된 데이터(nowLevel) 가져오기
            // int nowLevel = PlayerPrefs.GetInt("NowLevel", 1);
            int nowLevel = 22;
            Debug.Log($"NowLevel : {nowLevel}");

        // 레벨 버튼s 초기화
        // 레벨 버튼 배열 선언
        levelButtons = new Button[contents.childCount];
            // 레벨 버튼 세팅
            for (int i = 0; i < levelButtons.Length; i++)
            {
                levelButtons[i] = contents.GetChild(i).GetComponent<Button>();
                if(i >= nowLevel)
                {
                    levelButtons[i].interactable = false;
                }
            }
        }

        // 레벨 버튼 클릭 시 매개 변수로 받은 신 이름으로 신 이동한다
        public void LevelButtonSelect(string sceneName)
        {
            // Debug.Log($"{sceneName} 신으로 이동");
            fader.FadeTo(sceneName);
        }
        
        // 메뉴 가기
        public void ExitButton()
        {
            fader.FadeTo(loadToScene);
        }
    }
}

/*
게임 데이터 처리 : save / load
: 유저 데이터 : 유저가 게임을 플레이하면서 생산한 데이터
: 게임 종료 시에도 유지되어야 하는 데이터

: 파일 세이브 - 로컬 저장
1. 게임을 실행하면 저장된 게임 데이터가 있는지 없는지 파일 체크
파일이 없으면 - 유저 데이터들의 값을 초기 데이터로 초기화 후 저장하여 파일을 만든다
파일이 있으면 - 파일을 읽어서 저장된 데이터로 유저 데이터들의 값을 초기화

2. 저장 위치/시점 고려

3. 저장 시 저장된 데이터와 지금 저장할 데이터의 비교

// Playerprefs save/load
PlayerPrefs.SetInt(string KeyName, int Value); // KeyName 이름으로 Value 값 저장
PlayerPrefs.GetInt(string KeyName)         // KeyName 이름으로 저장된 값 가져오기

PlayerPrefs.SetFloat(string KeyName, int Value); // KeyName 이름으로 Value 값 저장
PlayerPrefs.GetFloat(string KeyName)         // KeyName 이름으로 저장된 값 가져오기

PlayerPrefs.SetString(string KeyName, int Value); // KeyName 이름으로 Value 값 저장
PlayerPrefs.GetString(string KeyName)         // KeyName 이름으로 저장된 값 가져오기
*/

