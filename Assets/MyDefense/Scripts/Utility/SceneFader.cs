using UnityEngine;
using UnityEngine.UI;

namespace MyDefense
{
    // 신 시작 시 페이드 인, 신 종료 시 페이드 아웃 효과 구현
    public class SceneFader : MonoBehaviour
    {
        #region Field
        // 페이더 이미지
        public Image img;
        #endregion

        // 코루틴으로 구현
        // Fade In : 1초 동안 : 검정에서 완전 투명으로(이미지 알파 값 a : 1 -> a : 0)

        // Fade Out : 1초 동안 : 투명에서 완전 검정으로(이미지 알파 값 a : 0 -> a : 1)

        // 다른 신으로 이동 시 Fade Out 효과 후 LoadScene으로 이동
    }
}