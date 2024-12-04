using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Strategy
{
    public class ClientStrategy : MonoBehaviour
    {
        public GameObject dronePrefab; // 드론 프리팹
        public List<Vector3> spawnPoints = new List<Vector3>(); // 스폰 포인트 리스트

        private List<GameObject> _activeDrones = new List<GameObject>(); // 활성화된 드론 리스트
        private List<IManeuverBehaviour> _components = new List<IManeuverBehaviour>();

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
            GameObject drone = Instantiate(dronePrefab, spawnPoints[i], Quaternion.identity);

            // 드론에 Drone 컴포넌트를 추가
            if (!drone.GetComponent<Drone>())
            {
                drone.AddComponent<Drone>();
            }

            // 드론을 리스트에 추가
            _activeDrones.Add(drone);

            // 드론 파괴 시 콜백 등록
            drone.GetComponent<Drone>().OnDestroyed += OnDroneDestroyed;

            ApplyRandomStrategies(drone);
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

        private void ApplyRandomStrategies(GameObject drone)
        {
            // 드론에 다양한 매뉴버 컴포넌트 추가
            _components.Add(drone.AddComponent<WeavingManeuver>());
            _components.Add(drone.AddComponent<BoppingManeuver>());
            _components.Add(drone.AddComponent<FallbackManeuver>());

            // 랜덤으로 하나의 전략을 적용
            int index = Random.Range(0, _components.Count);
            drone.GetComponent<Drone>().ApplyStrategy(_components[index]);
        }

        private void OnDroneDestroyed(GameObject drone)
        {
            // 드론을 리스트에서 제거
            if (_activeDrones.Contains(drone))
            {
                _activeDrones.Remove(drone);
            }

            // 모든 드론이 파괴되었는지 확인
            if (_activeDrones.Count == 0)
            {
                OnAllDronesDestroyed();
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                OnAllDronesDestroyed();

            }
        }
        private void OnAllDronesDestroyed()
        {
            // 첫 번째 대사 출력
            GameManager.Instance.csvReader.StartDialogue(0);

            // 2초 뒤 두 번째 대사 출력
            StartCoroutine(StartSecondDialogueAfterDelay());
        }

        private IEnumerator StartSecondDialogueAfterDelay()
        {
            yield return new WaitForSeconds(2f); // 2초 대기
            GameManager.Instance.csvReader.StartDialogue(1); // 두 번째 대사 출력
        }

    }
}
