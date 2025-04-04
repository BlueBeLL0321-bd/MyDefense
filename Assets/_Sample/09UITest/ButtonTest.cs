using UnityEngine;


namespace Sample
{
    public class ButtonTest : MonoBehaviour
    {
        // Fire 버튼 클릭 시 (실행)호출되는 함수
        public void FireButton()
        {
            Debug.Log("Fire 버튼을 눌렀습니다");
        }

        // Jump 버튼 클릭 시 "플레이어가 점프하였습니다" 출력
        public void JumpButton()
        {
            Debug.Log("플레이어가 점프하였습니다");
        }
    }
}