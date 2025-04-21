using UnityEngine;
using System.Collections;

namespace Sample
{
    // Coroutine 함수 테스트
    public class CoroutineTest : MonoBehaviour
    {
        bool isCorou = false;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(isCorou == false)
            {
                Debug.Log("-----------------------------------------실행 1");

                StartCoroutine(CorouTest());
            }

            Debug.Log("실행 4");

        }


        //
        IEnumerator CorouTest()
        {
            isCorou = true;
            Debug.Log("-----------------------------------------실행 2");

            for (int i = 0; i < 3; i++)
            {
                Debug.Log($"-----------------------------------------실행 5-{i}");
                yield return new WaitForSeconds(0.1f); // 0.1초 지연
            }
            

            // 지연된 범위
            Debug.Log("-----------------------------------------실행 3");


            // 지연된 범위
        }

    }
}