using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform resetPoint;
    public CoinManager cm;
    public HealthManager hm;
    // Set this to the transform of the point where you want to reset the player

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death"))
        {

            transform.position = resetPoint.position;
            //other.gameObject.SetActive(true);
            //cm.coinCount = 0;
           
        }
        if (other.gameObject.CompareTag("Lava"))
        {

            transform.position = resetPoint.position;
            //other.gameObject.SetActive(true);
            //cm.coinCount = 0;

        }
    }
}
