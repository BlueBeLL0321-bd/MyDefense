using UnityEngine;

namespace MyDefense
{
    // 탄환(발사체)을 관리하는 클래스
    public class Bullet : MonoBehaviour
    {
        #region Field
        // 타깃 오브젝트
        private Transform target;
        // 이동 속도
        public float moveSpeed = 70f;
        #endregion

        public void SetTarget(Transform _target)
        {
            this.target = _target;
        }

        // Update is called once per frame
        void Update()
        {
            if(target == null)
            {
                return;
            }

            // 이동하기
            // dir.magnitude = 두 벡터 간의 거리
            Vector3 dir = target.position - this.transform.position;
            float distanceThisFrame = Time.deltaTime * moveSpeed; // 이번 프레임에 이동하는 거리
            if(dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        }

        // 타깃을 맞추다
        void HitTarget()
        {
            Debug.Log("Hit Target!!!");
            // 타깃 게임 오브젝트 킬
            Destroy(target.gameObject);

            // 탄환 게임 오브젝트 킬
            Destroy(this.gameObject);
        }
    }
}