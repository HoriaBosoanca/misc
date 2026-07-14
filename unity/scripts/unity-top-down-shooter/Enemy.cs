using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private float pastHealth;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = GameObject.Find("Player");
        
        pastHealth = GetComponent<Entity>().health;
    }
    
    // main execution
    void Update()
    {
        FollowPlayer();
        DamageCheck();
    }
    void FollowPlayer()
    {
        if(player)
        {
            RotateATowardsB(transform.position, player.transform.position);
            agent.SetDestination(player.transform.position);
        }
        else{
            agent.SetDestination(transform.position);
        }
    }
    void DamageCheck()
    {
        if(pastHealth != GetComponent<Entity>().health)
        {
            // changes color to red for short period of time after being hit
            GetComponent<SpriteRenderer>().color = new Color(255,0,0,255); //red
            StartCoroutine("ChangeColor");
        }
        pastHealth = GetComponent<Entity>().health;
    }
    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(255,255,255,255); //normal (white)
    }








    // root operations
    void RotateATowardsB(Vector2 A, Vector2 B)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Atan2(B.y - A.y,B.x - A.x) * Mathf.Rad2Deg - 90));
    }
}
