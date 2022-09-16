using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    [SerializeField] Text fpsText;
    public float deltaTime;
    private void Start()
    {
//        Application.targetFrameRate = 60;
    }
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "fps: " + Mathf.Ceil(fps).ToString();
    }
}
