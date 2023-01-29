using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Animator playerAnimator;
    Camera mainCamera;
    public float damage;
    public float distance;
    public string shotAnimName;
    public string reloadAnimName;
    public ParticleSystem ParticleSystem;
    public bool useParticleSystem;
    public bool inspection;
    public string inspectionAnimName;
    public AudioSource AudioSource;
    public ParticleSystem bulletCartridge;
    public bool useBulletCartridge;
    public float ammo;
    public float maxAmmo;
    public Text AmmoText;
    public float firingDelay;
    public bool isReadyToFire = true;
    public bool isAutomatic;
    private void Start()
    {
        mainCamera = Camera.main;
        AmmoText.text = "Ammo: " + ammo;
    }

    public void Shot()
    {
        if(isAutomatic == true)
        {
            if (Input.GetButton("Fire1") && ammo != 0 && isReadyToFire == true)
            {
                isReadyToFire = false;
                Invoke("MakeReadyToFire", firingDelay);
                ammo = ammo - 1f;
                AmmoText.text = "Ammo: " + ammo;
                if (useParticleSystem == true)
                {
                    ParticleSystem.Play();
                }
                if (useBulletCartridge == true)
                {
                    bulletCartridge.Play();
                }
                playerAnimator.Play(shotAnimName);
                AudioSource.Play();
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
                {
                    if (hit.transform.tag.Equals("Enemy"))
                    {
                        hit.transform.GetComponent<Enemy>().Hurt(damage);
                    }
                }
            }
        }
        if (isAutomatic == false)
        {
            if (Input.GetButtonDown("Fire1") && ammo != 0 && isReadyToFire == true)
            {
                isReadyToFire = false;
                Invoke("MakeReadyToFire", firingDelay);
                ammo = ammo - 1f;
                AmmoText.text = "Ammo: " + ammo;
                if (useParticleSystem == true)
                {
                    ParticleSystem.Play();
                }
                if (useBulletCartridge == true)
                {
                    bulletCartridge.Play();
                }
                playerAnimator.Play(shotAnimName);
                AudioSource.Play();
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
                {
                    if (hit.transform.tag.Equals("Enemy"))
                    {
                        hit.transform.GetComponent<Enemy>().Hurt(damage);
                    }
                }
            }
        }
    }
    public void MakeReadyToFire()
    {
        isReadyToFire = true;
    }
    public void Reload()
    {
        if (Input.GetKey(KeyCode.R) && ammo != maxAmmo)
        {
            playerAnimator.Play(reloadAnimName);
            ammo = maxAmmo;
            AmmoText.text = "Ammo: " + ammo;
        }
    }
    public void Inspection()
    {
        if(inspection = true)
        {
            if (Input.GetKey(KeyCode.F))
            {
                playerAnimator.Play(inspectionAnimName);
            }
        }
    }
    void Update()
    {
        Shot();
        Reload();
        Inspection();
    }
}



