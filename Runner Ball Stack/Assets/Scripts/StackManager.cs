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
        //if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        MoveBalls();
    }

    public void StackBalls(GameObject newBall)
    {
        int sizeOfBallList = allBalls.Count;
        Vector3 pos = allBalls[sizeOfBallList - 1].transform.position;
        pos.z -= 1;
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

    public void MoveBalls()
    {
        Vector3 pos;
        for(int i = 1; i < allBalls.Count; i++)
        {
            pos = allBalls[i-1].transform.position;
            pos.z -= 1;
            allBalls[i].transform.DOMove(pos, followDuration);
        }
    }

}
