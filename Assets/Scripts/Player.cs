using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int vida = 100;
    Animator playerAnimator;
    GameObject enemy;

    // Start is called before the first frame update
    void Awake()
    {
        transform.tag = "Player";
        playerAnimator = FindObjectOfType<Animator>();
        enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            playerAnimator.SetTrigger("Death");
        }

        if (Input.GetMouseButtonDown(0))
        {
            playerAnimator.SetTrigger("Punching");
            if (Vector3.Distance(transform.position, enemy.transform.position) < 1.5f)
            {
                Atacar();
            }
        }       

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAnimator.SetTrigger("FlyingKick");
            if (Vector3.Distance(transform.position, enemy.transform.position) < 3f)
            {
                Atacar();
            }           
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            playerAnimator.SetTrigger("DanceFlair");
        }

    }

    void Atacar()
    {
        enemy.GetComponent<Enemy>().vida -= 50;
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {

    //        vida -= 10;
    //    }
    //}

}
