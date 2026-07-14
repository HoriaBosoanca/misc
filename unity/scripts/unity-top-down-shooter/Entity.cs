using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Editable")]
    
    [SerializeField] private bool hasSpecialDeathImplementation;
    public float health;
    public float damage;
    
    // variables
    [Header("Mandatory Publics")]
    public float maxHealth; //is refrenced in health bars
    public bool colliding;
    public GameObject collidedObject;
    public Entity collidedObjectScript;
    
    void Awake()
    {
        maxHealth = health;
    }
    void Update()
    {
        Die();
    }
    void Die()
    {
        if(health <= 0 && !hasSpecialDeathImplementation)
        {
            StartCoroutine("WaitForEndOfFrame");
            Destroy(gameObject);
        }
    }
    public void Damage()
    {
        if(collidedObjectScript)
        {
            collidedObjectScript.health -= damage;
        }
    }



    //get info about collision
    void OnCollisionEnter2D(Collision2D col)
    {
        
        colliding = true;
        collidedObject = col.gameObject;
        if (collidedObject && colliding)
        {
            collidedObjectScript = col.gameObject.GetComponent<Entity>();
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        colliding = false;
    }
    IEnumerator WaitForEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
    }
}