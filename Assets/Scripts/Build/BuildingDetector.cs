using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;                    //건물 감지 범위
    private Vector3 lastPosition;                       //플레이어의 마지막 위치 저장
    private float moveThreshold = 0.1f;                 //이동 감지 임계값
    private ConstructibleBuilding currentNearbyBuilding;//현재 가까이 있는 건설 가능한 건물

    private void CheckForBuilding()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);   //감지 범위 내의 모든 콜라이더를 찾음

        float clossetDistance = float.MaxValue;     //가장 가까운 거리의 초기값
        ConstructibleBuilding closestBuilding = null;       //가장 가까운 아이템 초기값

        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();    //건물 감지
            if (building != null && building.canBuild && !building.isConstructed)   //건물 조건 확인
            {
                float distance = Vector3.Distance(transform.position, building.transform.position); //거리 계산
                if (distance < clossetDistance)     //더 가까운 아이템을 발견 시 업데이트
                {
                    clossetDistance = distance;
                    closestBuilding = building;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
