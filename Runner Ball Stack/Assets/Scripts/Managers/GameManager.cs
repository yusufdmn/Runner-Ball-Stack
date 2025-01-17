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
    [SerializeField] AnalyticsManager analyticsManager;
    [SerializeField] LevelManager levelManager;
    [SerializeField] UnlockObstacleManager unlockObstacleManager;

    [SerializeField] BallRotation ballRotation;

    public AudioManager audioManager;
    [SerializeField] CanvasManager canvasManager;

    [SerializeField] GameObject firstBall;
    FirstBallMoveForward firstBallMoveForward;
    RotateInAxisX rotateInAxisX;

    public bool isGameStarted;
    public bool isFinishModeStarted;
    public bool isGameFinished;

    CameraMovement cameraMovement;

    private void Start()
    {
        levelManager.SetLevelInfo();
        unlockObstacleManager.SetUnlockObstacleInfo();

        cameraMovement = Camera.main.GetComponent<CameraMovement>();
        firstBallMoveForward = firstBall.GetComponent<FirstBallMoveForward>();
        rotateInAxisX = firstBall.GetComponent<RotateInAxisX>();
    }

    public void StartTheGame()
    {
        isGameStarted = true;
        canvasManager.HideMainMenu();
        firstBallMoveForward.enabled = true;
        ballRotation.StartRotation();        
    }

    public void EndTheGame()
    {
        isGameFinished = true;
        canvasManager.DisplayEndPanel();
    }

    public void CompleteThelevel()
    {
        ScoreManager.Instance.FinishLevelSuccessfully();
        levelManager.PasstoNextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        try
        {
            analyticsManager.SendEventMessage("LevelCompleted");
        }
        catch
        { 
            
        }

    }


    public void Failed()
    {
        audioManager.PlayFailSound();
        StackManager.Instance.gameObject.SetActive(false);
        cameraMovement.enabled = false;
        isGameFinished = true;
        canvasManager.DisplayFailPanel();
    }

    public void RetryLevel()
    {
        ScoreManager.Instance.ResetLevelScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SkipLevel()
    {
        analyticsManager.SendEventMessage("SkipLevel");
        ScoreManager.Instance.ResetLevelScore();
        levelManager.PasstoNextLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}