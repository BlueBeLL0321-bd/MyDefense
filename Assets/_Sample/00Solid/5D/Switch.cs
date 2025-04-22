using Solid_Defendency;
using UnityEngine;

namespace Solid
{
    public class Switch : MonoBehaviour
    {
        // public Door door;
        // public Robot robot;
        public Transform switchTransform;
        private ISwitchable client; // Door, Robot

        private void Start()
        {
            client = switchTransform.GetComponent<ISwitchable>();
            Debug.Log(client);
        }

        // 한 번 누르면 문 열리고 다시 한번 누르면 문이 닫힌다
        public void Toggle()
        {
            if (client.IsActive)
            {
                client.Deactivate();
            }
            else
            {
                client.Activate();
            }
        }
    }
}