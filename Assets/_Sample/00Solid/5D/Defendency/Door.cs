using UnityEngine;

namespace Solid_Defendency
{
    public class Door : MonoBehaviour
    {
        public void Open()
        {
            Debug.Log("문이 열린다");
        }

        public void Close()
        {
            Debug.Log("문이 닫힌다");
        }
    }
}