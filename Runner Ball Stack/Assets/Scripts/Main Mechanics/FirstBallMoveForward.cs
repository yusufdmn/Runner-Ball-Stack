using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBallMoveForward : MonoBehaviour
{
    float x;
    float maxPosX = 2.5f;

    [SerializeField] float speedForward = 1.5f;
    [SerializeField] float speedSide = 7;
    [SerializeField] float speedSideMobil = 0.4f;

    Touch touch;
    Vector3 moveVector;

    private void Start()
    {
        StartCoroutine(SpeedUp());
    }

    void Update()
    {
        KeepBallOnWay();

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            moveVector = new Vector3(touch.deltaPosition.x * speedSideMobil, 0, speedForward);
            transform.Translate(moveVector * Time.deltaTime, Space.World);
        }
        else
        {
            moveVector = new Vector3(0, 0, speedForward);
            transform.Translate(moveVector * Time.deltaTime, Space.World);
        }

        /*x = Input.GetAxis("Horizontal");

        moveVector = new Vector3(x * speedSide, 0, speedForward);
        transform.Translate(moveVector * Time.deltaTime, Space.World);
       */

        //#if UNITY_ANDROID
        /*   if (Input.touchCount > 0)
           {
               touch = Input.GetTouch(0);
               moveVector = new Vector3(touch.deltaPosition.x * speedSideMobil, 0, speedForward);
               transform.Translate(moveVector * Time.deltaTime, Space.World);
           }
           else
           {
               moveVector = new Vector3(0, 0, speedForward);
               transform.Translate(moveVector * Time.deltaTime, Space.World);
           }*//*
   #endif
   #if UNITY_EDITOR
           x = Input.GetAxis("Horizontal");

           moveVector = new Vector3(x * speedSide, 0, speedForward);
           transform.Translate(moveVector * Time.deltaTime, Space.World);
   #endif*/
    }


    IEnumerator SpeedUp()
    {
        while(speedForward < 7)
        {
            speedForward += 0.07f;
            yield return new WaitForEndOfFrame();
        }
    }

    void KeepBallOnWay()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -maxPosX, maxPosX);
        transform.position = pos;
    }

}
