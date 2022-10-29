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
    [SerializeField] float scaleDuration = 0.15f;
    [SerializeField] float followDuration = 0f;
    [SerializeField] float moveSideDuration = 0.4f;


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
            yield return new WaitForSeconds(0.04f);
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
       /* float x;
        for (int i = 1; i < stackedBalls.Count; i++)
        {
            x = stackedBalls[i - 1].transform.position.x;
          //  Vector3 targetPos = stackedBalls[i].transform.position;
          //  targetPos.x = x;
            StartCoroutine(ManipulatePosition(stackedBalls[i].transform, x));
        }*/

        
        float x;
        for(int i = 1; i < stackedBalls.Count; i++)
        {
            x = stackedBalls[i - 1].transform.position.x;
            stackedBalls[i].transform.DOMoveX(x, moveSideDuration);
        }
    }

   /* IEnumerator Move(Transform ballTransform, Vector3 target)
    {
        ballTransform.position
        yield return null;
    }
    
    IEnumerator ManipulatePosition(Transform handledTransform, float targetX)
    { 
        int direction = ((handledTransform.position.x - targetX) > 0)? -1:1;
        Vector3 pos = handledTransform.position;
        float firstX = handledTransform.position.x;
        float speed = 0.5f;
        while(Mathf.Abs(handledTransform.position.x - firstX) !<= 0.1f)
        {
            pos.x += Time.deltaTime * speed * direction;
            handledTransform.position = pos;
        }
        yield return null;
    }
*/
    public void MoveBallsToOrigin()
    {
        if (stackedBalls.Count <= 1)
            return;
        float origin = stackedBalls[0].transform.position.x;
        stackedBalls[1].transform.DOMoveX(origin, moveSideDuration);

        float x;
        for (int i = 2; i < stackedBalls.Count; i++)
        {
            x = stackedBalls[i - 1].transform.position.x;
            stackedBalls[i].transform.DOMoveX(x, moveSideDuration);
        }
    }
}
