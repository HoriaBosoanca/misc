using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;
    public string state;
    private PlayerController pc;
    public bool a;
    void Start()
    {
        anim = GameObject.Find("PlayerVisual").GetComponent<Animator>();
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        if(!pc){
            Debug.LogWarning("ERROR: no player controller found!");
        }
    }

    void Update()
    {
        a = pc.HasMoveInput();
        if(pc.HasMoveInput() && pc.canJump){
            state = "Run";
        }
        if(!pc.canJump){
            state = "Jump";
        }
        if(!pc.HasMoveInput() && pc.canJump){
            state = "Idle";
        }

        anim.Play(state);
    }
}
