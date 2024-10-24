using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Attack : MonoBehaviour
{
    private GameManager gm; 

    //public GameObject particle;   

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            /*Instantiate(particle, transform.position, Quaternion.identity);
            gm.Score();
            Destroy(other.gameObject);*/
        }
    }
}
