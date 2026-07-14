using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private Entity entity;
    private bool canAtack;
    public float atackDelay;
    void Awake()
    {
        entity = GetComponent<Entity>();
        canAtack = true;
    }
    void Update()
    {
        if(entity.colliding && canAtack && entity.collidedObject.CompareTag("Player_"))
        {
            entity.Damage();
            StartCoroutine("AtackCooldown");
        }
    }

    IEnumerator AtackCooldown()
    {
        canAtack = false;
        yield return new WaitForSeconds(atackDelay);
        canAtack = true;
    }
}
