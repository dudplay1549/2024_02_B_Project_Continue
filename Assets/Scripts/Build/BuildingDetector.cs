using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;                    //�ǹ� ���� ����
    private Vector3 lastPosition;                       //�÷��̾��� ������ ��ġ ����
    private float moveThreshold = 0.1f;                 //�̵� ���� �Ӱ谪
    private ConstructibleBuilding currentNearbyBuilding;//���� ������ �ִ� �Ǽ� ������ �ǹ�

    private void CheckForBuilding()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);   //���� ���� ���� ��� �ݶ��̴��� ã��

        float clossetDistance = float.MaxValue;     //���� ����� �Ÿ��� �ʱⰪ
        ConstructibleBuilding closestBuilding = null;       //���� ����� ������ �ʱⰪ

        foreach (Collider collider in hitColliders)
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();    //�ǹ� ����
            if (building != null && building.canBuild && !building.isConstructed)   //�ǹ� ���� Ȯ��
            {
                float distance = Vector3.Distance(transform.position, building.transform.position); //�Ÿ� ���
                if (distance < clossetDistance)     //�� ����� �������� �߰� �� ������Ʈ
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
