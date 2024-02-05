using System;
using UnityEngine;

namespace Sample
{
    public static class LessonVectors
    {
        // Максимальное количество баллов = 10

        ///Пример: Возвращает лежит ли точка point на внутри окружности с центром center и радиусом radius 
        public static bool IsPointInCircle(Vector2 center, float radius, Vector2 point)
        {
            return Vector2.Distance(center, point) <= radius;
        }

        ///Пример: Возвращает лежит ли точка point на отрезке (start, end) 
        public static bool IsPointOnLine(Vector2 start, Vector2 end, Vector2 point)
        {
            Vector2 vectorAP = point - start;
            Vector2 vectorAB = end - start;

            //Проверка коллинеарности векторов:
            float crossProduct = Vector3.Cross(vectorAP, vectorAB).z;
            if (Mathf.Abs(crossProduct) > float.Epsilon)
                return false;

            //Проверка проекций:
            float dotProduct = Vector2.Dot(vectorAP, vectorAB);
            float squaredLengthAB = vectorAB.sqrMagnitude;

            if (dotProduct < 0 || dotProduct > squaredLengthAB)
                return false;

            return true;
        }
        
        /**
         * Простая (1 балл)
         *
         * Проверить, лежит ли окружность с центром в (x1, y1) и радиусом r1 целиком внутри
         * окружности с центром в (x2, y2) и радиусом r2.
         * Вернуть true, если утверждение верно
         */
        public static bool CircleInsideCircle(
            Vector2 c1, float r1,
            Vector2 c2, float r2
        )
        {
            float x1 = c1.x;
            float y1 = c1.y;
            float x2 = c2.x;
            float y2 = c2.y;

            if ((r1 + Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))) <= r2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /**
        * Простая (2 балла)
        *
        * Определить, с какой стороны лежит ли точка point относительно прямой, которая задается точками start и end.
        * Если точка относительно прямой расположена слева то вернуть -1, если справа, то 1, если точка лежит на прямой, то вернуть 0
        */
        public static float PointRelativeLine(Vector2 start, Vector2 end, Vector2 point)
        {
            float c = (point.x - start.x) * (end.y - start.y) - (point.y - start.y) * (end.x - start.x);

         
            if (c > 0)
            {
                return 1;
            }
            else if (c < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
            
        }


        /**
        * Простая (2 балла)
        *
        * Определить, лежит ли точка point внутри или на периметре прямоугольника,
        * который задается двумя точками start и end
        */
        public static bool IsPointInRectangle(Vector2 start, Vector2 end, Vector2 point)
        {


            float minX = Math.Min(start.x, end.x);
            float maxX = Math.Max(start.x, end.x);
            float minY = Math.Min(start.y, end.y);
            float maxY = Math.Max(start.y, end.y);

            if (point.x >= minX && point.x <= maxX && point.y >= minY && point.y <= maxY)
            {
                
                return true;
            }
            else
            {
                return false;
            }
            

        }
        
        /**
         * Средняя (3 балла)
         *
         * Определить число ходов, за которое шахматный король пройдёт из клетки start в клетку end.
         * Шахматный король одним ходом может переместиться из клетки, в которой стоит,
         * на любую соседнюю по вертикали, горизонтали или диагонали.
         * Ниже точками выделены возможные ходы короля, а крестиками -- невозможные:
         *
         * xxxxx
         * x...x
         * x.K.x
         * x...x
         * xxxxx
         *
         * Если клетки start и end совпадают, вернуть 0.
         * Если любая из клеток некорректна, бросить IllegalArgumentException().
         *
         * Пример: kingMoveNumber(Square(3, 1), Square(6, 3)) = 3.
         * Король может последовательно пройти через клетки (4, 2) и (5, 2) к клетке (6, 3).
         */
        public static int KingMoveNumber(Vector2Int start, Vector2Int end)
        {
       

            int deltaX = Math.Abs(end.x - start.x);
            int deltaY = Math.Abs(end.y - start.y);

           
            if (deltaX == 0 && deltaY == 0)
            {
                
                return 0;
            }
            else if (deltaX <= 1 && deltaY <= 1)
            {
                return 1;
            }

            return Math.Max(deltaX, deltaY);
        }

        /**
        * Сложная (2 балла)
        *
        * Определить, пересекает ли луч ray окружность с центром center и радиусом radius
        * Описание алгоритмов см. в Интернете
        * Если начало луча находится внутри или на окружности, то вернуть false 
        */
        public static bool RayCircleIntersect(Ray ray, Vector3 center, float radius)
        {
            Vector3 ro = ray.origin;
            Vector3 rd = ray.direction;
            Vector3 oc = ro - center;

            float t = -Vector3.Dot(oc, rd) + Mathf.Sqrt(Mathf.Pow(Vector3.Dot(oc, rd), 2) - oc.sqrMagnitude + radius * radius);
            float x = ro.x + t * rd.x;
            float y = ro.y + t * rd.y;
            float z = ro.z + t * rd.z;
            Vector3 intersectionPoint = ro + t * rd;
            float distance = Vector3.Distance(center, intersectionPoint);
            float distance2 = Vector3.Distance(center, ray.origin);
            Vector3 intersection = ray.GetPoint(Mathf.Floor(Vector3.Distance(ro, center)));
            float distanceIntersection = Mathf.Floor(Vector3.Distance(center, intersection));

            if(distance2 <= radius)
            {
                return false;
            }
            else
            {
                return distanceIntersection <= radius;
            }
            

            if (t < 0)
            {
                return false;
            }

            if (distance <= radius)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
    }
}