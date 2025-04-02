using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyDefense
{
    // 맵의 타일을 관리하는 클래스
    public class Tile : MonoBehaviour
    {
        #region Field

        // 마우스를 올려 놓으면 변하는 색
        // public Color hoverColor;
        // 타일의 원래 색깔
        // private Color startColor;

        // 마우스를 올려 놓으면 변하는 매터리얼
        public Material hoverMaterial;
        // 마우스를 올려 놓으면 변하는 매터리얼
        private Material startMaterial;

        // 파일의 Renderer
        private Renderer renderer;

        #endregion

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // 참조
            renderer = this.transform.GetComponent<Renderer>();

            // 초기화
            // startColor = renderer.material.color;
            startMaterial = renderer.material;
        }

        private void OnMouseDown()
        {
            // Debug.Log("이 스크립트가 붙어 있는 타일 위에 터렛을 설치");
            // Instantiate(towerPrefab, this.transform.position, Quaternion.identity);
            Instantiate(BuildManager.Instance.GetTowerToBuild(), this.transform.position, Quaternion.identity);
        }

        private void OnMouseEnter()
        {
            // renderer.material.color = hoverColor;
            renderer.material = hoverMaterial;
        }

        private void OnMouseExit()
        {
            // renderer.material = startColor;
            // renderer.material.color = Color.white;

            renderer.material = startMaterial;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}