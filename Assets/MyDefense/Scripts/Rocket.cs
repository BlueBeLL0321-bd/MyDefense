using Unity.VisualScripting;
using UnityEngine;

namespace MyDefense
{
    public class Rocket : Bullet
    {
        #region Field

        // 대미지 영역
        public float damageRange = 3.5f;
        // enemy 오브젝트 태그 스트링
        public string enemyTag = "Enemy";

        #endregion

        // 타깃을 맞추어 폭발하여 대미지 영역에 있는 적 킬 - 불렛
        protected override void HitTarget()
        {
            // 타격 이펙트 효과
            GameObject effectGo = Instantiate(bulletImpactPrefab, this.transform.position, Quaternion.identity);
            Destroy(effectGo, 2f);

            // 폭발
            Explosion();

            // 로켓 게임 오브젝트 킬
            Destroy(this.gameObject);
        }

        // 폭발 - 대미지 영역(3.5f)에 있는 적을 찾아 킬
        // 폭발 지점으로부터 각 Enemy들과의 거리를 구하여 거리에 반비례하여 대미지 주기
        private void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
            // 대미지 영역 안의 모든 충돌체에서 Enemy 찾기
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.tag == enemyTag)
                {
                    // 거리 구하기
                    float distance = Vector3.Distance(this.transform.position, hitCollider.transform.position);
                    // 거리 비례로 대미지 구하기
                    float damage = attackDamage * ((damageRange - distance) / damageRange);

                    Enemy enemy = hitCollider.GetComponent<Enemy>();
                    if(enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }

                }
            }
        }

        // 기즈모 대미지 영역 그리기
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, damageRange);
        }
    }
}