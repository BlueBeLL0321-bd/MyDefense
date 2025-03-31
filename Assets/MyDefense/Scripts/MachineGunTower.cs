using UnityEngine;

namespace MyDefense
{
    public class MachineGunTower : MonoBehaviour
    {
        #region Field
        // 공격 범위
        public float attackRange = 7f;

        // 가장 가까운 적
        private Transform target;

        // Enemy tag
        public string enemyTag = "Enemy";

        // Search 타이머
        public float searchTimer;
        private float countdown;
        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // UpdateTarget 함수를 즉시 0.5초마다 반복해서 호출한다
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        // 가장 가까운 적 찾기
        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            // 최소 거리일 때의 적 구하기
            float minDistance = float.MaxValue;
            GameObject nearEnemy = null;

            foreach(var enemy in enemies)
            {
                float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    nearEnemy = enemy;
                }
            }

            // Debug.Log($"minDistance : {minDistance}");
            if (nearEnemy != null && minDistance <= attackRange)
            {
                target = nearEnemy.transform;
                Debug.Log("Find Target");
            }
            else
            {
                target = null;
            }
        }

        // Update is called once per frame
        void Update()
        {
            /*// 가장 가까운 적 찾기
            countdown += Time.deltaTime;
            if (countdown >= searchTimer)
            {
                // 타이머 기능(함수) 호출
                UpdateTarget();

                // 타이머 초기화
                countdown = 0f;*/
            }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, attackRange);
        }
    }
}