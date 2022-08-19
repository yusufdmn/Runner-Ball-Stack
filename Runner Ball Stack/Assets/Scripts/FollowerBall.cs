using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FollowerBall : MonoBehaviour
{
    public int ownIndex;
    [SerializeField] float followDuration = 0.5f;
    Vector3 pos;
    void LateUpdate()
    {
        pos = StackManager.Instance.allBalls[ownIndex - 1].transform.position;
        pos.z -= 1;
        //transform.DOMove(pos, followDuration);
        transform.position = Vector3.Lerp(transform.position, pos, followDuration);
    }
}
