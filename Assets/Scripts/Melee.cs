using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Melee : MonoBehaviour
{
    public Animator playerAnimator;
    public AudioSource audioSource;
    public string kickAnimName;
    public string inspectionAnimName;
    Camera mainCamera;
    public float damage;
    public float distance;
    public Text ammoText;
    public Text fireModeText;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    public void Kick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            playerAnimator.Play(kickAnimName);
            audioSource.Play();
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Enemy"))
                {
                    hit.transform.GetComponent<Enemy>().Hurt(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
    public void Inspection()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAnimator.Play(inspectionAnimName);
        }
    }
    private void Update()
    {
        Kick();
        Inspection();
        ammoText.text = "";
        fireModeText.text = "";
    }
}
