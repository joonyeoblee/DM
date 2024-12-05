using UnityEngine;
using System.Collections;

namespace Strategy
{
    public class FallbackManeuver : MonoBehaviour, IManeuverBehaviour
    {
        // 드론에 후퇴 동작(전략)을 적용
        public void Maneuver(Drone drone)
        {
            if (drone != null)
                StartCoroutine(Fallback(drone)); // Coroutine 시작
        }

        // 드론 후퇴 동작을 수행하는 Coroutine
        IEnumerator Fallback(Drone drone)
        {
            float time = 0; // 이동 시간
            bool isReverse = false; // 방향 전환 여부
            float speed = drone.speed; // 드론의 이동 속도
            Vector3 startPosition = drone.transform.position; // 초기 위치 저장
            Vector3 endPosition = startPosition;
            endPosition.z = startPosition.z + drone.fallbackDistance; // 후퇴 목표 위치 설정

            while (true)
            {
                time = 0; // 시간 초기화
                Vector3 start = drone.transform.position; // 현재 위치
                Vector3 end = (isReverse) ? startPosition : endPosition; // 목표 위치 설정 (후퇴/복귀)

                // 드론 이동
                while (time < speed)
                {
                    drone.transform.position =
                        Vector3.Lerp(
                            start, end, time / speed);

                    time += Time.deltaTime;
                    yield return null; // 다음 프레임까지 대기
                }

                yield return new WaitForSeconds(1); // 방향 전환 전 1초 대기
                isReverse = !isReverse; // 방향 전환
            }
        }
    }
}
