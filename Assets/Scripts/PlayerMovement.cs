using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb2d;

    public Animator anim;

    public Joystick joystick;

    public Transform interactor;

    public float moveSpeed;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        //Set animation blend tree
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        //Face last direction you moved in
        if (joystick.Horizontal > 0 || joystick.Horizontal < 0 || joystick.Vertical > 0 || joystick.Vertical < 0)
        {
            anim.SetFloat("LastHorizontal", joystick.Horizontal);
            anim.SetFloat("LastVertical", joystick.Vertical);
        }

        //Rotate interactor
        if (joystick.Horizontal > 0.5f)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (joystick.Horizontal < -0.5f)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, -90);
        }
        if (joystick.Vertical > 0.5f)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (joystick.Vertical < -0.5f)
        {
            interactor.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        //Movement
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.deltaTime);
    }
}
