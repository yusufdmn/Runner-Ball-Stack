using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpOneAxis : MonoBehaviour
{
    [SerializeField] float lerpSpeed;
    [SerializeField] Vector3 firstPoint;
    [SerializeField] Vector3 secondPoint;
    float t = 0;
    int direction;

    private void Start()
    {
        firstPoint = transform.position;
        secondPoint = transform.position;
        firstPoint.x += 2.5f;
        secondPoint.x += -2.5f;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(firstPoint, secondPoint, t);
        t += Time.deltaTime * lerpSpeed * direction;
        if (t >= 1)
            direction = -1;
        else if (t <= 0)
            direction = 1;
    }

}
