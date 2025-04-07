using UnityEngine;

namespace MyDefense
{
    public class BuildMenu : MonoBehaviour
    {
        // MachineGunButton 클릭 시 호출되는 함수
        public void MachineGunButton()
        {
            // 빌드 매니저의 towerToBuild에 machineGunPrefab을 저장한다
            Debug.Log("towerToBuild에 machineGunPrefab을 저장한다");
            BuildManager.Instance.SetTowerToBuild(BuildManager.Instance.machineGunPrefab);
        }

        // RocketTowerButton 클릭 시 호출되는 함수
        public void RocketTowerButton()
        {
            Debug.Log("towerToBuild에 rocketTowerPrefab을 저장한다");
            BuildManager.Instance.SetTowerToBuild(BuildManager.Instance.rocketTowerPrefab);
        }
    }
}