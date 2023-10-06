using UnityEngine;

public class PacStudent : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Vector3[] path = new Vector3[]
    {
       new Vector3(12f, -2f, 0f),   // 向右走 4 个单位
        new Vector3(12f, -8f, 0f),  // 向下走 4 个单位
        new Vector3(21f, -8f, 0f),  // 向左走 4 个单位
        new Vector3(21f, -2f, 0f),
        new Vector3(32f, -2f, 0f),
        new Vector3(32f, -17f, 0f),
        new Vector3(21f, -17f, 0f),
        new Vector3(21f, -11f, 0f)
           // 向上走 4 个单位
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

            // 移动 PacStudent
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            // 设置动画参数
            SetAnimationParameters(moveDirection);

            // 如果接近目标位置，切换到下一个路径点
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentPathIndex++;
            }
        }
    }

    void SetAnimationParameters(Vector3 moveDirection)
    {
        // 计算朝向角度
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        // 调整角度范围为 [0, 360]
        angle = (angle + 360) % 360;

        // 根据角度设置动画参数
        GetComponent<Animator>().SetFloat("DirX", Mathf.Cos(angle * Mathf.Deg2Rad));
        GetComponent<Animator>().SetFloat("DirY", Mathf.Sin(angle * Mathf.Deg2Rad));
    }
}
