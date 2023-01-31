using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public LayerMask playerLayer;
    public Player player;
    private bool dead;
    public float Health = 100;
    public float vision;
    public float attackRadius;
    public float attackDamage;
    NavMeshAgent agent;
    public Animator animator;
    bool run = true;
    public AudioSource AudioSource;
    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletCartidge;
    public RuntimeAnimatorController animatorDeath;
    public ParticleSystem blood;
    public GameObject killScoreGO;
    //attacking player
    public Camera enemyCamera;
    public float distance;
    public float checkSpaceDistance;
    public GameObject playerGO;
    public float checkDelay;
    public float attackDelay;
    public float counter;
    bool allowToCheckPlayer = true;
    private void Start()
    {
        tag = "Enemy";
        agent = GetComponent<NavMeshAgent>();
    }
    public void CheckAttack()
    {
        if (Physics.CheckSphere(transform.position, attackRadius, playerLayer))
        {
            CheckPlayer();
        }
    }
    private void ChasePlayer()
    {
        if (Physics.CheckSphere(transform.position, vision, playerLayer))
        {
            if(run == true)
            {
                agent.SetDestination(player.transform.position);
                animator.Play("Move");
            }
        }
    }
    public void AttackPlayer()
    {
        counter = 0;
        AudioSource.Play();
        muzzleFlash.Play();
        bulletCartidge.Play();
        animator.Play("Attack");
        if (Physics.CheckSphere(transform.position, attackRadius, playerLayer))
        {
            RaycastHit hit;
            if (Physics.Raycast(enemyCamera.transform.position, enemyCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Player"))
                {
                    player.Hurt(attackDamage);
                }
            }
        }
    }
    public void Update()
    {
        if (dead == false)
        {
            ChasePlayer();
            CheckAttack();
        }
    }

    public void Hurt(float Damage)
    {
        blood.Play();
        Health = Health - Damage;
        if (Health <= 0)
        {
            blood.Stop();
            dead = true;
            agent.SetDestination(transform.position);
            animator.runtimeAnimatorController = animatorDeath;
        }
    }
    public void CheckPlayer()
    {
        if(allowToCheckPlayer == true)
        {
            counter += 0.02f;
            if (counter >= attackDelay)
            {
                counter = 0f;
                transform.LookAt(playerGO.transform.position);
                RaycastHit hit;
                if (Physics.Raycast(enemyCamera.transform.position, enemyCamera.transform.forward, out hit, checkSpaceDistance))
                {
                    if (hit.transform.tag.Equals("Player"))
                    {
                        allowToCheckPlayer = false;
                        counter += 0.02f;
                        AttackPlayer();
                        run = false;
                        Invoke("allowToCheck", checkDelay);
                    }
                    else
                    {
                        run = true;
                    }
                }
            }
        }
    }
    public void allowToCheck()
    {
        allowToCheckPlayer = true;
    }
    public void killScorePlus()
    {
        killScoreGO.GetComponent<KillScore>().scorePlus();
    }
}