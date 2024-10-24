using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Player player;

    public int damage;
    [Space]

    public bool playerInSigth;
    [Space]

    public float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    public void StunPlayer()
    {
        if(playerInSigth == true)
        {
            player.playerIsStunning = true;
        }
        
    }

    void Start()
    {
        anim = GetComponent<Animator>();

        playerInSigth = false;
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(playerInSigth == true)
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;

                //Poner nombre del trigger de attack para la animacion
                //anim.SetTrigger("");
                Debug.Log("Attack");

                //quitar para que funcione con un trigger en la animacion
                StunPlayer();
            }
        }
    }
}
