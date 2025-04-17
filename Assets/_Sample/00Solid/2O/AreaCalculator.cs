using UnityEngine;

namespace Solid.OpenClose
{
    public class AreaCalculator : MonoBehaviour
    {
        public Rectangle rectangle;
        public Circle circle;



        // 매개 변수로 받은 도형의 면적 구해서 반환하는 함수
        public float GetShapeArea(Shape shape)
        {
            return shape.CalculateArea();
        }

        private void Start()
        {
            float rectArea = GetShapeArea(rectangle);
            float circleArea = GetShapeArea(circle);
        }

        /*// 매개 변수로 받은 사각형 도형의 면적 구해서 반환하는 함수
        public float GetRectangleArea(Rectangle rectangle)
        {
            return rectangle.CalculateArea();
        }

        // 매개 변수로 받은 원 도형의 면적 구해서 반환하는 함수
        public float GetCircleArea(Circle circle)
        {
            return circle.CalculateArea();
        }*/
    }
}

