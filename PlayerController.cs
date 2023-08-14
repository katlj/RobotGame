using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 1f;
    public Animator characterAnimator;
    public float runSpeed = 5f;
    private Rigidbody playerRB;
    public bool isGrounded = true;
    public float turnSpeed = 45;
    public GameObject bullet;
    public GameObject bulletOrigin;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float speed = walkSpeed;
        float inputV = Input.GetAxis("Vertical");
        float inputH = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;

        }
        // move the player forward while forward input is pressed
        if (inputV > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
            characterAnimator.SetFloat("Speed", speed);
        }

        else
        {
            characterAnimator.SetFloat("Speed", 0);

        }
        if (inputH != 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * inputH * speed);
        }
        // gets player to jump by accesing rigidbody
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        // when space hold the robot will jump
        {
            playerRB.AddForce(Vector3.up * 5f, ForceMode.Impulse);
            // gets player ot jump once on impulse
            characterAnimator.SetTrigger("Jump");
            // get the player animator to get the trigger of jumping added ot it
            isGrounded = false;
        }
        // get the input of the the f to trigger fire bullets when pressed sown
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, bulletOrigin.transform.position, transform.rotation);
            WriteMessagetoConsole("Fired Bullet");
        }
    }
    //when player jump get them to jump again
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            
        }
    }
            private void WriteMessagetoConsole(string message)
            {
                Debug.Log(message);
            }
        




            //this gets speed to math the walk speed
            //Naming Convention all variables stay with a lowerrcase
            //Charcter variable not assigned means you can  drag player object into 
            // exit  time in trnsitins means this is going to finsih first before anything else continues.
            // this makes things chop[py so you get rid of exit time so that everything is 
            //  more smooth
            //transition mode into compeletion---> then the animation
            // the bars on top of animations allow you to declare how fast or sllow you want to trsnitions
            // into the animations
            //code is the direction for the animation-- what the program has to do
            // animator itself is like the bridge between the code and the animation-- helps control the animation
            // set up the conditions to align with parameters so it can execute the animation.

        
    
}


