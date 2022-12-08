using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpOneAxis : MonoBehaviour
{
    float lerpSpeed;
    [SerializeField] Transform firstTarget;
    [SerializeField] Transform secondTarget;
    Vector3 firstPoint;
    Vector3 secondPoint;
    [SerializeField] float minRandomSpeed;
    [SerializeField] float maxRandomSpeed;
    [SerializeField] Vector3 offset;
    float t = 0;
    int direction;

    private void Start()
    {
        lerpSpeed = Random.Range(minRandomSpeed, maxRandomSpeed);
        firstPoint = firstTarget.position + offset;
        secondPoint = secondTarget.position + offset;

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
