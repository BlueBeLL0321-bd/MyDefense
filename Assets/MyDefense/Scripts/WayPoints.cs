using UnityEngine;

namespace MyDefense
{
    public class WayPoints : MonoBehaviour
    {
        #region Field
        public static Transform[] wayPoints;
        #endregion

        private void Awake()
        {
            // 초기화
            wayPoints = new Transform[this.transform.childCount];
            for (int i = 0; i < wayPoints.Length; i++)
            {
                wayPoints[i] = this.transform.GetChild(i);

                Debug.Log($"{wayPoints[i].position}");
            }
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }
    }
}