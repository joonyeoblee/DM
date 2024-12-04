using UnityEngine;

namespace Strategy
{
    public class Drone : MonoBehaviour
    {

        // Ray parameters
        private RaycastHit _hit;
        private Vector3 _rayDirection;
        private float _rayAngle = -45.0f;
        private float _rayDistance = 15.0f;

        // Movement parameters
        public float speed = 1.0f;
        public float maxHeight = 5.0f;
        public float weavingDistance = 1.5f;
        public float fallbackDistance = 10.0f;

        public delegate void DroneDestroyed(GameObject drone);
        public event DroneDestroyed OnDestroyed;

        void Start()
        {
            _rayDirection =
                transform.TransformDirection(Vector3.back)
                * _rayDistance;

            _rayDirection =
                Quaternion.Euler(_rayAngle, 0.0f, 0f)
                * _rayDirection;
        }

        public void ApplyStrategy(IManeuverBehaviour strategy)
        {
            strategy.Maneuver(this);
        }

        void Update()
        {
            Debug.DrawRay(transform.position,
                _rayDirection, Color.blue);

            if (Physics.Raycast(
                transform.position,
                _rayDirection, out _hit, _rayDistance))
            {

                if (_hit.collider)
                {
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