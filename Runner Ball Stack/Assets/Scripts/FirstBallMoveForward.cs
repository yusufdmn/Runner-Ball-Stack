using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBallMoveForward : MonoBehaviour
{
    float x;
    [Range(1, 100)]
    [SerializeField] float speedForward;
    [SerializeField] float speedSide;
    [SerializeField] float speedSideMobil;

    Touch touch;
    Vector3 moveVector;
    void Update()
    {

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            moveVector = new Vector3(touch.deltaPosition.x * speedSideMobil, 0, speedForward);
        }
        else
        {
            moveVector = new Vector3(0, 0, speedForward);
        }
        transform.Translate(moveVector * Time.deltaTime, Space.World);
#endif
#if UNITY_EDITOR
        x = Input.GetAxis("Horizontal");

        moveVector = new Vector3(x * speedSide, 0, speedForward);
        transform.Translate(moveVector * Time.deltaTime, Space.World);
#endif
    }

}
