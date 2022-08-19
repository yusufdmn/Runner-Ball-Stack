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


    public List<GameObject> allBalls;
    [SerializeField] float scaleDuration = 0.1f;
    [SerializeField] float followDuration = 0.5f;


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        FollowNextBall();
        if (x != 0)
            MoveBalls();
        else
            MoveBallsToOrigin();
        
    }

    public void StackBalls(GameObject newBall)
    {
        int sizeOfBallList = allBalls.Count;
        Vector3 pos = allBalls[sizeOfBallList - 1].transform.position;
        pos.z -= 1f;
        newBall.transform.position = pos;
        allBalls.Add(newBall);
        StartCoroutine(BigSlowEffect());

    }

    public IEnumerator BigSlowEffect()
    {
        float bigScale = 1.4f;
        Vector3 scale = Vector3.one;
        for (int i = allBalls.Count - 1; i > 0; i--)
        {
            int index = i;
            allBalls[index].transform.DOScale(bigScale, scaleDuration).OnComplete(() =>
                allBalls[index].transform.DOScale(scale, scaleDuration)
            );
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void FollowNextBall()
    {
        float z;
        for(int i = 1; i < allBalls.Count; i++)
        {
            //currentPos = allBalls[i].transform.position - Vector3.forward;
            z = allBalls[i - 1].transform.position.z - 1;
            allBalls[i].transform.DOMoveZ(z, followDuration);
        }
    }

    public void MoveBalls()
    {
        float x;
        for(int i = 1; i < allBalls.Count; i++)
        {
            x = allBalls[i-1].transform.position.x;
            allBalls[i].transform.DOMoveX(x, followDuration);
        }
    }

    public void MoveBallsToOrigin()
    {
        float origin = allBalls[0].transform.position.x;
        foreach (GameObject ball in allBalls)
            ball.transform.DOMoveX(origin, followDuration);
    }
}
