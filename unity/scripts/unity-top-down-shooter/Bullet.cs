using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //refrences
    private Rigidbody2D rb;
    //variables
    private float bulletSpeed;
    void Awake()
    {
        //refrences
        rb = GetComponent<Rigidbody2D>();
        //variables
        bulletSpeed = 1000;

        MoveForward();
        StartCoroutine("AutoDestroy");
    }
    void MoveForward()
    {
        rb.AddForce(transform.up * Time.deltaTime * bulletSpeed, ForceMode2D.Impulse);
    }
    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    } 
}
