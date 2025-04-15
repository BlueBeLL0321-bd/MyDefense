using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyDefense
{
    public class TileUI : MonoBehaviour
    {
        #region Field
        public GameObject offset;

        // 선택한 타일
        private Tile selectTile;

        // 업그레이드 Cost Text
        public TextMeshProUGUI upgradeCost;
        public Button upgradeButton;
        #endregion

        // 타일 UI 보이기
        public void ShowTileUI(Tile tile)
        {
            selectTile = tile;
            this.transform.position = tile.transform.position;

            if (selectTile.IsUpgrade)
            {
                // 업그레이드 성공
                Debug.Log("COMPLETE!!!");
                upgradeButton.interactable = false;
            }
            else
            {
                // 업그레이드 가격 표시
                upgradeCost.text = tile.bluePrint.upgradeCost.ToString() + "G";
                upgradeButton.interactable = true;
            }

            offset.SetActive(true);
        }

        // 타일 UI 감추기
        public void HideTileUI()
        {
            offset.SetActive(false);
        }

        // 업그레이드 버튼 클릭 시 호출
        public void UpgradeTower()
        {
            // 선택된 타일에 있는 타워를 업그레이드한다.
            selectTile.UpgradeTower();

            // 선택한 타일을 해제한다
            BuildManager.Instance.DeselectTile();
        }
    }
}

