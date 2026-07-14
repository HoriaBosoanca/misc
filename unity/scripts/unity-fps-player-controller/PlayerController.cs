using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //references
    private Rigidbody rb;
    private GameObject cam;
    private GameObject playerVisual;

    //vars
    float yRotation = 0;
    float xRotation = 0;
    public float sensX;
    public float sensY;
    public float speed;
    public bool canJump;
    public float jumpForce;
    Vector3 velocityBeforeJump;
    void Start()
    {
        //refs
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("Main Camera");
        playerVisual = GameObject.Find("PlayerVisual");

        //cusror
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //vars
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        Camera();
    }

    void FixedUpdate(){
        Move();
        GroundCheck();
        Jump();
        FixAnimationBug();
    }

    void Move(){
        if(canJump){
            Vector3 force = CalculateMoveVelocity();
            force.y = rb.velocity.y;
            rb.velocity = force;
        }
        else{
            Vector3 force = (CalculateMoveVelocity() + velocityBeforeJump) / 2;
            force.y = rb.velocity.y;
            rb.velocity = force;
        }
    }

    void Jump(){
        if(Input.GetKey(KeyCode.Space) && canJump){
            velocityBeforeJump = CalculateMoveVelocity();
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
    
    void GroundCheck(){
        Physics.SphereCast(new Ray(playerVisual.transform.position + new Vector3(0,1f,0), Vector3.down.normalized), 0.49f, out RaycastHit hit);
        // Uses "playerVisual" bc it is situated directly at player's feet (unlike "player", which is slightly off) 
        //Starts 0.1f above ground because it gets buggy if ray collides at the point it is initiated
        if(hit.distance <= 0.5f){
            canJump = true;
        }
        else{
            canJump = false;
        }
    }

    void Camera(){

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void FixAnimationBug(){
        playerVisual.transform.position = transform.position;
        playerVisual.transform.rotation = transform.rotation;
    }

    public float InputX(){
        return Input.GetAxis("Horizontal");
    }
    public float InputZ(){
        return Input.GetAxis("Vertical");
    }
    
    public bool HasMoveInput(){
        return Mathf.Abs(InputX()) > 0 || Mathf.Abs(InputZ()) > 0;
    }

    Vector3 CalculateMoveVelocity(){
        return (transform.forward * InputZ() + transform.right * InputX()).normalized * speed;
    }
}
