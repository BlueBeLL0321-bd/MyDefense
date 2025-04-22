using UnityEngine;

namespace Solid
{
    public class Robot : MonoBehaviour, ISwitchable
    {
        public bool isActive;
        public bool IsActive => isActive;

        public void Activate()
        {
            isActive = true;
            Debug.Log("로봇이 기동을 한다");
        }

        public void Deactivate()
        {
            isActive = false;
            Debug.Log("로봇이 멈춘다");
        }
    }
}