using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private Entity parentEntity;
    void Awake()
    {
        slider = GetComponent<Slider>();
        parentEntity = GameObject.Find("Player").GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = parentEntity.health / parentEntity.maxHealth;
        //transform.position = new Vector2(transform.parent.parent.position.x, transform.parent.parent.position.y + 0.7f);
    }
}
