using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandage : MonoBehaviour
{
    [SerializeField] private int healing;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player_"))
        {
            col.gameObject.GetComponent<Entity>().health += healing;
            Destroy(gameObject);
        }
    }
}
