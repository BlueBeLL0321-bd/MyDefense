using UnityEngine;

namespace Sample
{
    // 싱글톤 패턴 클래스
    public class Singleton
    {
        // 클래스의 인스턴스를 정적(static) 변수 선언
        private static Singleton instance;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        // public한 메서드로 instance 접근하기
        /*public static Singleton Instance()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }*/

        //
        // 자
        /*public Singleton()
        {

        }*/
    }
}

/*
// 싱글톤 패턴 클래스
1. 하나의 인스턴스만 존재 : new를 1번만 호출
2. 클래스의 인스턴스가 전역적 접근 가능 : 변수를 static 선언
*/