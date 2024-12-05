using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    public Transform target; // 따라갈 대상
    public float followSpeed = 2f; // 따라가는 속도
    public float rotationSpeed = 10f; // 회전 속도
    public float stopDistance = 1f; // 멈추는 거리

    void Start()
    {
        target = GameManager.Instance.player.transform;
    }
    void Update()
    {
        if (target != null)
        {
            // 타겟과의 거리 계산
            float distance = Vector3.Distance(transform.position, target.position);

            // 멈출 거리보다 멀면 이동
            if (distance > stopDistance)
            {
                // 목표 위치와 현재 위치 차이에서 Y축 제거
                Vector3 direction = (target.position - transform.position);
                direction.y = 0; // Y축 이동 제거
                direction = direction.normalized;

                // 이동 위치 계산
                transform.position += direction * followSpeed * Time.deltaTime;
            }


            // 타겟을 향해 회전
            Vector3 lookDirection = target.position - transform.position;
            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
    // 사망 처리 속도 0으로 변경
    public void Dead()
    {
        followSpeed = 0f;
    }

}
