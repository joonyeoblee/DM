using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Strategy
{
    public class ClientStrategy : MonoBehaviour
    {
        public GameObject dronePrefab; // 드론 프리팹
        public List<Vector3> spawnPoints = new List<Vector3>(); // 스폰 포인트 리스트

        private GameObject _drone;
        private List<IManeuverBehaviour> _components = new List<IManeuverBehaviour>();

        // 코루틴을 통해 1초마다 타켓 소환
        private void SpawnDrone(int i)
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


            // 드론 생성
            _drone = Instantiate(dronePrefab, spawnPoints[i], Quaternion.identity);

            // 드론에 Drone 컴포넌트를 추가
            if (!_drone.GetComponent<Drone>())
            {
                _drone.AddComponent<Drone>();
            }

            ApplyRandomStrategies();
        }

        // 1초마다 드론을 5대까지 생성
        IEnumerator SpawnDroneCoroutine()
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnDrone(i);
                yield return new WaitForSeconds(1f);
            }
        }

        public void ShootGameStart()
        {
            Debug.Log("ShootGameStart");
            StartCoroutine(SpawnDroneCoroutine());
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
    }
}
