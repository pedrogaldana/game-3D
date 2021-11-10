using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public int vida = 100;
    private GameObject player;
    private NavMeshAgent navMesh;
    private bool podeAtacar;
    Animator enemyAnimator;

    void Start()
    {
        podeAtacar = true;
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            enemyAnimator.SetTrigger("Death");
            navMesh.isStopped = true;
        }
        else
        {
            if (player.GetComponent<Player>().vida <= 0)
            {
                enemyAnimator.SetTrigger("Eating");
            }
            else
            {
                navMesh.destination = player.transform.position;
                if (Vector3.Distance(transform.position, player.transform.position) < 3f)
                {
                    Atacar();
                    navMesh.isStopped = true;
                }
                else
                {
                    navMesh.isStopped = false;
                }
            }
        }
    }

    void Atacar()
    {
        if (podeAtacar)
        {
            enemyAnimator.SetTrigger("Attack");
            StartCoroutine("TempoAtaque");
            player.GetComponent<Player>().vida -= 20;
        }
    }

    IEnumerator TempoAtaque()
    {
        podeAtacar = false;
        yield return new WaitForSeconds(1);
        podeAtacar = true;
    }
}
