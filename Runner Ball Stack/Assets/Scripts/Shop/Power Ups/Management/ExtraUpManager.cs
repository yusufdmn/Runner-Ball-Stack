using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraUpManager : PowerUpManager
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform parent;
    [SerializeField] Transform FirstBall;
    Vector3 pos;

    private void Start()
    {
        base.SetInfo();
        SetPosition();
        AddExtraBalls();
    }

    void SetPosition()
    {
        pos = FirstBall.position;
        pos.x = -10;
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

    public void AddExtraOneBall()
    {
        GameObject extraBall = Instantiate(ball, pos, Quaternion.identity, parent);

        SetComponentSettings(extraBall);
        StackManager.Instance.stackedBalls.Add(extraBall);
    }
}
