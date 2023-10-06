using UnityEngine;

public class PacStudent : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Vector3[] path = new Vector3[]
    {
       new Vector3(12f, -2f, 0f),   // ������ 4 ����λ
        new Vector3(12f, -8f, 0f),  // ������ 4 ����λ
        new Vector3(21f, -8f, 0f),  // ������ 4 ����λ
        new Vector3(21f, -2f, 0f),
        new Vector3(32f, -2f, 0f),
        new Vector3(32f, -17f, 0f),
        new Vector3(21f, -17f, 0f),
        new Vector3(21f, -11f, 0f)
           // ������ 4 ����λ
    };

    private int currentPathIndex = 0;

    void Update()
    {
        MoveOnPath();
    }

    void MoveOnPath()
    {
        if (currentPathIndex < path.Length)
        {
            Vector3 targetPosition = path[currentPathIndex];
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            // �ƶ� PacStudent
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // ���ö�������
            SetAnimationParameters(moveDirection);

            // ����ӽ�Ŀ��λ�ã��л�����һ��·����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentPathIndex++;
            }
        }
    }

    void SetAnimationParameters(Vector3 moveDirection)
    {
        // ���㳯��Ƕ�
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        // �����Ƕȷ�ΧΪ [0, 360]
        angle = (angle + 360) % 360;

        // ���ݽǶ����ö�������
        GetComponent<Animator>().SetFloat("DirX", Mathf.Cos(angle * Mathf.Deg2Rad));
        GetComponent<Animator>().SetFloat("DirY", Mathf.Sin(angle * Mathf.Deg2Rad));
    }
}
