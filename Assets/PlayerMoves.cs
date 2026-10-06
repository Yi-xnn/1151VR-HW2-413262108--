using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public Vector2 playerPos; // 角色座標 Vector2

    public Vector2[] speeds = new Vector2[] // Vector2 陣列存各階段speed
    {
        new Vector2(0.01f, 0.0f), //往前
        new Vector2(0.01f, 0.01f), //往上
        new Vector2(0.01f, -0.01f) //往下
    };
    private int step = 0; // 目前動作階段

    void Start()
    {
        playerPos = transform.position; //將角色的初始位置記錄進 playerPos
    }

    void Update()
    {
        // 每個影格持續執行：處理移動與條件判斷
        if (step == 0)
        {
            playerPos.x += speeds[0].x;
            if (playerPos.x >= 0.0f)
            {
                step = 1;
            }
        }
        else if (step == 1)
        {
            playerPos.x += speeds[1].x;
            playerPos.y += speeds[1].y;
            if (playerPos.y >= 3.0f)
            {
                step = 2;
            }
        }
        else if (step == 2)
        {
            playerPos.x += speeds[2].x;
            playerPos.y += speeds[2].y;
            if (playerPos.y <= 0.0f)
            {
                step = 3; // 到達終點
            }
        }
        transform.position = playerPos;// 更新畫面上的角色位置
    }
}