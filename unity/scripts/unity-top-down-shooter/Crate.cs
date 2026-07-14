using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    [Header("!!! Manual References")]
    [SerializeField] private GameObject bandage;
    void Update()
    {
        if(GetComponent<Entity>().health <= 0)
        {
            Instantiate(bandage, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
