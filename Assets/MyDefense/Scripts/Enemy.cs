using UnityEngine;

namespace MyDefense
{
    public class Enemy : MonoBehaviour
    {
        // 필드
        #region Field
        // 이동 속도
        public float speed = 5f;

        private Vector3 targetPosition;
        // wayPoint 오브젝트의 트랜스폼 객체
        private Transform target;
        // wayPoints 배열의 인덱스
        private int wayPointIndex = 0;
        #endregion
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // 초기화
            wayPointIndex = 0;
            target = WayPoints.wayPoints[wayPointIndex];
        }

        // Update is called once per frame
        void Update()
        {
            // 이동 구현
            Vector3 dir = target.position - this.transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);

            // targetPosition 도착 판정
            float distance = Vector3.Distance(target.position, this.transform.position);
            if (distance <= 0.1f)
            {
                // 다음 타깃 세팅
                GetNextTargetPosition();
            }
        }

        // 다음 타깃 얻어 오기
        void GetNextTargetPosition()
        {
            if(wayPointIndex == WayPoints.wayPoints.Length - 1)
            {
                Destroy(this.gameObject);
                return;
            }
            wayPointIndex++;

            target = WayPoints.wayPoints[wayPointIndex];
        }
    }
}
