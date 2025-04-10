using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefense
{
    // 탄환(발사체)을 관리하는 클래스 - 모든 발사체의 부모 클래스
    public class Bullet : MonoBehaviour
    {
        #region Field
        // 타깃 오브젝트
        private Transform target;
        // 이동 속도
        public float moveSpeed = 70f;

        // 타격 이펙트 프리팹
        public GameObject bulletImpactPrefab;

        // 공격 대미지
        [SerializeField] protected float attackDamage = 50f;
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
            transform.Translate(dir.normalized * Time.deltaTime * moveSpeed, Space.World);

            // 타깃을 바라보며 이동하기
            transform.LookAt(target);
        }

        // 타깃을 맞추어 적을 킬 - 불렛
        protected virtual void HitTarget()
        {
            // 타격 이펙트 효과
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            // 타깃에게 대미지 주기
            Damage(target);

            // 탄환 게임 오브젝트 킬
            Destroy(this.gameObject);
        }

        // 매개 변수로 들어온 타깃에게 대미지 주기
        protected void Damage(Transform _target)
        {
            // 타깃 게임 오브젝트 킬 - 원 샷 원 킬
            // Destroy(_target.gameObject);

            // attackDamage만큼 타깃의 Health 감산
            Enemy enemy = _target.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }
}