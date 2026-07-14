using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [Header("Editable")]
    [SerializeField] private float speed;

    [Header("Read Only")]
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    //refrences
    private Camera cam;

    //vars
    private Rigidbody2D rb;
    public Vector2 mousePos;

    void Awake()
    {
        //refrences
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    // main execution
    void Update()
    {
        Move();
        LookAtMouse();
        MoveCamera();
        MoveCanvas();
    }




    // abstraction
    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //rb.velocity = new Vector2(horizontalInput, verticalInput).normalized * Time.deltaTime * speed;
        transform.position += new Vector3(horizontalInput, verticalInput, 0).normalized * Time.deltaTime * speed;
    }
    void LookAtMouse()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        RotateATowardsB(gameObject.transform.position, mousePos);
    }
    void MoveCamera()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
    void MoveCanvas()
    {
        GameObject.Find("Player Canvas").transform.position = transform.position;
    }



    // root operations
    void RotateATowardsB(Vector2 A, Vector2 B)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Atan2(B.y - A.y,B.x - A.x) * Mathf.Rad2Deg - 90));
    }
}
