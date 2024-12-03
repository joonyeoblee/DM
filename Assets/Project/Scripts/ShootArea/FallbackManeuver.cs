using UnityEngine;
using System.Collections;

namespace Strategy
{
    public class FallbackManeuver :
        MonoBehaviour, IManeuverBehaviour
    {

        public void Maneuver(Drone drone)
        {
            StartCoroutine(Fallback(drone));
        }

        IEnumerator Fallback(Drone drone)
        {
            float time = 0;
            float speed = drone.speed;
            Vector3 startPosition = drone.transform.position;
            Vector3 endPosition = startPosition;
            endPosition.z = startPosition.z + drone.fallbackDistance;
            Debug.Log("Start" + startPosition);
            Debug.Log("End" + endPosition);

            while (time < speed)
            {
                drone.transform.position =
                    Vector3.Lerp(
                        startPosition, endPosition, time / speed);

                time += Time.deltaTime;

                yield return null;
            }
        }
    }
}