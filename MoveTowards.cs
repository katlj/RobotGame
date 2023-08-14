using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    //get to know where the enemy object is so it can move toward
    public float speed = 5f;// speed of enemy
    private bool hasReachedTarget = false;

    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        //want to look for player when game starts
        //uppercase GameObject is a class, one of its methods is findobjects
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {
        //the actual code to do this action every frame
        //want it to reach target if it hasnt done it already
        if (!hasReachedTarget)
        {// transform.position is based on the game object the script is attached to
            //normalized makes usre it always happens

            Vector3 direction = (targetTransform.position - transform.position).normalized;
            Vector3 movement = new Vector3(direction.x, 0, direction.z) * speed * Time.deltaTime;
            transform.position += movement;
            transform.rotation = Quaternion.LookRotation(movement);
            //quarternion is the three dimensional rotation values
        }
    }
        private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player")) 
        {
            hasReachedTarget = true;
            Debug.Log("Object has reached the target");

        }
      }
    private void OnTriggerEnter(Collider other)
    {//collision with another object the player destroys 
        if (other.gameObject.tag == "Player") 
        {
            Destroy(gameObject);
        }
    }

}

