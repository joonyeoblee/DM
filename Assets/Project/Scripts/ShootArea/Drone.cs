using UnityEngine;

namespace Strategy
{
    public class Drone : MonoBehaviour
    {
        // Ray(광선) 관련 변수
        private RaycastHit _hit;
        private Vector3 _rayDirection;
        private float _rayAngle = -45.0f;
        private float _rayDistance = 15.0f;

        // 드론 이동 관련 변수
        public float speed = 1.0f; // 드론의 이동 속도
        public float maxHeight = 5.0f; // 드론의 최대 높이
        public float weavingDistance = 1.5f; // 좌우 이동 거리
        public float fallbackDistance = 10.0f; // 후퇴 거리

        // 드론 파괴 시 호출될 이벤트 델리게이트
        public delegate void DroneDestroyed(GameObject drone);
        public event DroneDestroyed OnDestroyed;

        void Start()
        {
            // Ray 방향 초기화 (뒤쪽으로 발사)
            _rayDirection =
                transform.TransformDirection(Vector3.back)
                * _rayDistance;

            // Ray 방향에 각도 적용
            _rayDirection =
                Quaternion.Euler(_rayAngle, 0.0f, 0f)
                * _rayDirection;
        }

        // 전략 패턴에서 특정 행동(전략)을 적용하는 함수
        public void ApplyStrategy(IManeuverBehaviour strategy)
        {
            strategy.Maneuver(this);
        }

        void Update()
        {
            // Ray를 시각적으로 디버깅하기 위해 표시
            Debug.DrawRay(transform.position,
                _rayDirection, Color.blue);

            // Ray가 충돌한 경우 처리
            if (Physics.Raycast(
                transform.position,
                _rayDirection, out _hit, _rayDistance))
            {
                if (_hit.collider)
                {
                    // 충돌된 경우 Ray 색상 변경
                    Debug.DrawRay(
                        transform.position,
                        _rayDirection, Color.green);
                }
            }
        }

        private void OnDestroy()
        {
            // 드론 파괴 시 이벤트 호출
            OnDestroyed?.Invoke(gameObject);
        }
    }
}
