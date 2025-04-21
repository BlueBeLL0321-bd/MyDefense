using UnityEngine;

namespace Solid_Interface
{
    // 이동 속도를 가지고 이동 가능한 유닛
    public interface IMoveable
    {
        public float MoveSpeed { get; set; }
        public float Accelation { get; set; }
        public void GoForward();
        public void GoBack();
        public void TurnLeft();
        public void TurnRight();
    }
}
