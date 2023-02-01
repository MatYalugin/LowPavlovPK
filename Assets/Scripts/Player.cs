using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    public float Health = 100;
    public float MaxHealth = 100;
    public float armor = 100;
    public float maxArmor = 100;
    public Text HealthText;
    public Text armorText;
    public GameObject DeathMenu;
    public GameObject controlsTip;
    // Update is called once per frame
    void Update()
    {
        controls();
        goToMain();
    }
    public void goToMain()
    {
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.Y))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Hurt(float damage)
    {
        if(armor != 0)
        {
            armor = armor - damage;
            Health = Health - damage / 2;
            armorText.text = "Armor: " + armor;
            HealthText.text = "Health: " + Health;

        }
        if(armor <= 0)
        {
            Health = Health - damage;
            HealthText.text = "Health: " + Health;
        }
        HealthText.text = "Health: " + Health;
        if (Health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            DeathMenu.SetActive(true);
            playerAnimator.Play("FPSLookOff");
        }
    }
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void controls()
    {
        if (Input.GetKey(KeyCode.Escape) && Input.GetKey(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            controlsTip.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.U))
        {
            controlsTip.SetActive(false);
        }
    }
}
