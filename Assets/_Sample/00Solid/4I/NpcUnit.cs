using UnityEngine;

namespace Solid_Interface
{
    // NPC 유닛 : 이동 가능, 대화 가능
    public class NpcUnit : MonoBehaviour, IMoveable
    {
        public float MoveSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public float Accelation { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void GoBack()
        {
            throw new System.NotImplementedException();
        }

        public void GoForward()
        {
            throw new System.NotImplementedException();
        }

        public void TurnLeft()
        {
            throw new System.NotImplementedException();
        }

        public void TurnRight()
        {
            throw new System.NotImplementedException();
        }
    }
}

