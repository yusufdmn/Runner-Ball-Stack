using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUIAnimations : MonoBehaviour
{
    [SerializeField] Animator[] animators;   
    public void PlayAnimations()
    {
        foreach (Animator anim in animators)
        {
            anim.enabled = true;
        }
    }
}