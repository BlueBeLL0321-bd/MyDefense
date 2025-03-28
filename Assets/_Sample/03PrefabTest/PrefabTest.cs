using UnityEngine;
using System.Collections;

namespace Sample
{
    public class PrefabTest : MonoBehaviour
    {
        public GameObject tilePrefab;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            // [1] 하나 생성
            // Vector3 position = new Vector3(5f, 0, 8f); // 생성할 위치 지정
            // Instantiate(tilePrefab, position, Quaternion.identity);

            // [2] n(10) x m(10) 생성 - 5 x 5 / 7 x 7
            // GenerateMap2(10, 10);

            // [3] 타일을 생성 - x 좌표를 0 ~ 500 사이의 랜덤 값, y = 0, z 좌표를 0 ~ 500 사이의 랜덤 값
            /*for (int i = 0; i < 10; i++)
            {
                GenerateRandomMapTile();
            }*/

            // [4] 타일을 10개 생성, 타일 하나 생성할 때 딜레이 0.2초 준다
            // 코루틴(Coroutine) - 0.2초 지연
            StartCoroutine(GenerateRandomMap());
        }

        void GenerateMap(int row, int column)
        {
            for(int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Vector3 position = new Vector3(j * 5f, 0, i * -5f);
                    Instantiate(tilePrefab, position, Quaternion.identity);
                }
            }
        }

        void GenerateMap2(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                   GameObject go = Instantiate(tilePrefab, this.transform);
                   go.transform.position = new Vector3(j * 5f, 0, i * -5f);
                }
            }
        }

        void GenerateRandomMapTile()
        {
            float xPos = Random.Range(0f, 50f);
            float zPos = Random.Range(-50f, 0f);
            Vector3 position = new Vector3(xPos, 0, zPos);
            Instantiate(tilePrefab, position, Quaternion.identity);
        }

        IEnumerator GenerateRandomMap()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector3 position = new Vector3(Random.Range(0f, 50f), 0, Random.Range(-50f, 0f));
                    Instantiate(tilePrefab, position, Quaternion.identity);

                    // 0.2초 딜레이
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
    }
}

/*
타일을 10 x 10으로 배치
*/
