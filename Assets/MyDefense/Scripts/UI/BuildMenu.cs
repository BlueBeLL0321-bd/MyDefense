using UnityEngine;

namespace MyDefense
{
    public class BuildMenu : MonoBehaviour
    {
        #region Field
        public TowerBluePrint machineGunTower;
        public TowerBluePrint rocketTower;
        public TowerBluePrint laserTower;
        #endregion

        // MachineGunButton 클릭 시 호출되는 함수
        public void MachineGunButton()
        {
            // 빌드 매니저의 towerToBuild에 machineGunPrefab을 저장한다
            BuildManager.Instance.SetTowerToBuild(machineGunTower);
        }

        // RocketTowerButton 클릭 시 호출되는 함수
        public void RocketTowerButton()
        {
            // 빌드 매니저의 towerToBuild에 rocketTowerPrefab을 저장한다
            BuildManager.Instance.SetTowerToBuild(rocketTower);
        }

        // LaserTowerButton 클릭 시 호출되는 함수
        public void LaserTowerButton()
        {
            // 빌드 매니저의 towerToBuild에 LaserTowerPrefab을 저장한다
            BuildManager.Instance.SetTowerToBuild(laserTower);
        }
    }
}