using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton Definiton
    private static GameManager instance;       // ******Definition of Singleton********
    public static GameManager Instance { get { return instance; } }
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

    [SerializeField] GameObject firstBall;
    FirstBallMoveForward firstBallMoveForward;
    RotateInAxisX rotateInAxisX;

    public bool isGameStarted;
    public bool isFinishModeStarted;
    public bool isGameFinished;

    private void Start()
    {
        firstBallMoveForward = firstBall.GetComponent<FirstBallMoveForward>();
        rotateInAxisX = firstBall.GetComponent<RotateInAxisX>();
    }

    public void StartTheGame()
    {
        isGameStarted = true;
        CanvasManager.Instance.HideMainMenu();
        firstBallMoveForward.enabled = true;
        rotateInAxisX.rotateSpeed = 230;
    }

    public void EndTheGame()
    {
        isGameFinished = true;
        CanvasManager.Instance.DisplayEndPanel();
    }

    public void PassToNextLevel()
    {
        ScoreManager.Instance.FinishGame();
        StartCoroutine(NextLevel());
    }

    public void Failed()
    {
        StackManager.Instance.gameObject.SetActive(false);
        Camera.main.GetComponent<CameraMovement>().enabled = false;
        isGameFinished = true;
        CanvasManager.Instance.DisplayFailPanel();
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}