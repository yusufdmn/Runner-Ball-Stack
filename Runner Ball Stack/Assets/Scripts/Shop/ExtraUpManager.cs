using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraUpManager : PowerUpManager
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform parent;
    [SerializeField] Transform FirstBall;

    private void Start()
    {
        AddExtraBalls();
    }

    public void AddExtraBalls()
    {
        for (int i = 1; i < base.powerUp.level; i++)
        {
            AddExtraOneBall();
        }
    }

    void SetComponentSettings(GameObject extraBall)
    {
        extraBall.AddComponent<BallTrigger>();
        extraBall.AddComponent<RotateInAxisX>();
    }

    void SetPosition(GameObject extraBall)
    {
        Vector3 pos = extraBall.transform.position;
        pos.y = FirstBall.position.y;
        extraBall.transform.position = pos;
    }

    public void AddExtraOneBall()
    {
        GameObject extraBall = Instantiate(ball, Vector3.zero, Quaternion.identity, parent);

        SetPosition(extraBall);
        SetComponentSettings(extraBall);
        StackManager.Instance.stackedBalls.Add(extraBall);
    }
}
