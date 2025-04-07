using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace MyDefense
{
    public class Rocket : Bullet
    {
        #region Field
        // 대미지 영역
        public float damageRange = 3.5f;

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

            // 탄환 게임 오브젝트 킬
            Destroy(this.gameObject);
        }

        // 폭발 - 대미지 영역(3.5f)에 있는 적을 찾아 킬
        private void Explosion()
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, damageRange);
            // 대미지 영역 안의 모든 충돌체에서 Enemy 찾기
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.tag == enemyTag)
                {
                    Destroy(hitCollider.gameObject);
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