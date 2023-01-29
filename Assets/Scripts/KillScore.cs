using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScore : MonoBehaviour
{
    public float score;
    public float requiredScore;
    public GameObject wonMenu;
    public Animator playerAnimator;
    public GameObject cursor;
    void Update()
    {
        if(score == requiredScore)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            wonMenu.SetActive(true);
            cursor.SetActive(false);
            playerAnimator.Play("StopPlayer");
        }
    }
    public void scorePlus()
    {
        score = score + 1f;
    }

}
