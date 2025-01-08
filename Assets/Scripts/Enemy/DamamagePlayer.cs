using System;
using UnityEngine;

public class DamamagePlayer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        try
            {
                other.gameObject.GetComponent<ControllerMC>().GetDamage();
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
            }
    }
}
