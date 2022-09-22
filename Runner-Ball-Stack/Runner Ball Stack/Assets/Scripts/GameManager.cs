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

    [SerializeField] CanvasManager canvasManager;

    [SerializeField] GameObject firstBall;
    FirstBallMoveForward firstBallMoveForward;
    RotateInAxisX rotateInAxisX;

    public bool isGameStarted;
    public bool isFinishModeStarted;
    public bool isGameFinished;

    CameraMovement cameraMovement;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
        firstBallMoveForward = firstBall.GetComponent<FirstBallMoveForward>();
        rotateInAxisX = firstBall.GetComponent<RotateInAxisX>();
    }

    public void StartTheGame()
    {
        isGameStarted = true;
        canvasManager.HideMainMenu();
        firstBallMoveForward.enabled = true;
        rotateInAxisX.rotateSpeed = 230;
    }

    public void EndTheGame()
    {
        isGameFinished = true;
        canvasManager.DisplayEndPanel();
    }

    public void CompleteThelevel()
    {
        ScoreManager.Instance.FinishLevelSuccessfully();
        StartCoroutine(NextLevel());
    }

    public void Failed()
    {
        StackManager.Instance.gameObject.SetActive(false);
        cameraMovement.enabled = false;
        isGameFinished = true;
        canvasManager.DisplayFailPanel();
    }

    public void RetryLevel()
    {
        ScoreManager.Instance.SkipLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}