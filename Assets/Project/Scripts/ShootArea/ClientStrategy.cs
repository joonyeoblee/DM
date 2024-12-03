using UnityEngine;
using System.Collections.Generic;

namespace Strategy
{
    public class ClientStrategy : MonoBehaviour
    {
        public GameObject dronePrefab; // 드론 프리팹
        public List<Vector3> spawnPoints = new List<Vector3>(); // 스폰 포인트 리스트

        private GameObject _drone;
        private List<IManeuverBehaviour> _components = new List<IManeuverBehaviour>();

        private void SpawnDrone()
        {
            if (dronePrefab == null)
            {
                Debug.LogError("Drone prefab is not assigned!");
                return;
            }

            if (spawnPoints == null || spawnPoints.Count == 0)
            {
                Debug.LogError("Spawn points are not assigned!");
                return;
            }

            // 스폰 포인트 리스트에서 랜덤으로 하나 선택
            Vector3 randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            // 드론 생성
            _drone = Instantiate(dronePrefab, randomSpawnPoint, Quaternion.identity);

            // 드론에 Drone 컴포넌트를 추가
            if (!_drone.GetComponent<Drone>())
            {
                _drone.AddComponent<Drone>();
            }

            ApplyRandomStrategies();
        }

        private void ApplyRandomStrategies()
        {
            // 드론에 다양한 매뉴버 컴포넌트 추가
            _components.Add(_drone.AddComponent<WeavingManeuver>());
            _components.Add(_drone.AddComponent<BoppingManeuver>());
            _components.Add(_drone.AddComponent<FallbackManeuver>());

            // 랜덤으로 하나의 전략을 적용
            int index = Random.Range(0, _components.Count);
            _drone.GetComponent<Drone>().ApplyStrategy(_components[index]);
        }

        void OnGUI()
        {
            if (GUILayout.Button("Spawn Drone"))
            {
                SpawnDrone();
            }
        }
    }
}
