using UnityEngine;
using System.Collections;

namespace Strategy
{
    public class BoppingManeuver : MonoBehaviour, IManeuverBehaviour
    {
        // 드론에 위아래로 움직이는 동작(전략)을 적용
        public void Maneuver(Drone drone)
        {
            if (drone != null)
                StartCoroutine(Bopple(drone)); // Coroutine 시작
        }

        // 드론이 위아래로 움직이는 동작을 수행하는 Coroutine
        IEnumerator Bopple(Drone drone)
        {
            float time; // 이동 시간
            bool isReverse = false; // 방향 전환 여부
            float speed = drone.speed; // 드론 이동 속도
            Vector3 startPosition = drone.transform.position; // 초기 위치
            Vector3 endPosition = startPosition;
            endPosition.y = startPosition.y - drone.maxHeight; // 아래쪽 목표 위치 설정

            while (true)
            {
                time = 0; // 시간 초기화
                Vector3 start = drone.transform.position; // 현재 위치
                Vector3 end = (isReverse) ? startPosition : endPosition; // 목표 위치 설정 (위/아래)

                // 드론 이동
                while (time < speed)
                {
                    drone.transform.position =
                        Vector3.Lerp(start, end, time / speed);
                    time += Time.deltaTime;
                    yield return null; // 다음 프레임까지 대기
                }

                yield return new WaitForSeconds(1); // 방향 전환 전 1초 대기
                isReverse = !isReverse; // 방향 전환
            }
        }
    }
}
