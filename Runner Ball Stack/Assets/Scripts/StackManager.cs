using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{

    #region Singleton Definiton
    private static StackManager instance;       // ******Definition of Singleton********
    public static StackManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion


    public List<GameObject> stackedBalls;
    [SerializeField] float scaleDuration = 0.1f;
    [SerializeField] float followDuration = 0.5f;
    [SerializeField] float moveSideDuration = 0.5f;


    void Update()
    {
               FollowNextBall();

               if (Input.touchCount > 0)
                   MoveBalls();
               else
                   MoveBallsToOrigin();

/*
#if UNITY_ANDROID
        if (Input.touchCount > 0)
            MoveBalls();
        else
            MoveBallsToOrigin();
#endif

#if UNITY_EDITOR
        float x = Input.GetAxis("Horizontal");
        if (x != 0)
            MoveBalls();
        else
            MoveBallsToOrigin();
#endif
*/

    }

    public void StackBalls(GameObject newBall)
    {
        int sizeOfBallList = stackedBalls.Count;
        Vector3 pos = stackedBalls[sizeOfBallList - 1].transform.position;
        pos.z -= 1f;
        newBall.transform.position = pos;
        stackedBalls.Add(newBall);
        StartCoroutine(BigSlowEffect());

    }

    public IEnumerator BigSlowEffect()
    {
        float bigScale = 1.4f;
        Vector3 scale = Vector3.one;
        for (int i = stackedBalls.Count - 1; i > 0; i--)
        {
            int index = i;
            stackedBalls[index].transform.DOScale(bigScale, scaleDuration).OnComplete(() =>
                stackedBalls[index].transform.DOScale(scale, scaleDuration)
            );
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void FollowNextBall()
    {
        float z;
        for(int i = 1; i < stackedBalls.Count; i++)
        {
            z = stackedBalls[i - 1].transform.position.z - 1;
            stackedBalls[i].transform.DOMoveZ(z, followDuration);
        }
    }

    public void MoveBalls()
    {
        float x;
        for(int i = 1; i < stackedBalls.Count; i++)
        {
            x = stackedBalls[i-1].transform.position.x;
            stackedBalls[i].transform.DOMoveX(x, moveSideDuration);
        }
    }

    public void MoveBallsToOrigin()
    {
        float origin = stackedBalls[0].transform.position.x;
        foreach (GameObject ball in stackedBalls)
            ball.transform.DOMoveX(origin, moveSideDuration);
    }
}
