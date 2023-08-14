using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
    //need bullet to move forward and something happen when collide with something

{
    public float bulletSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//moves it forward
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        //Tranlate is a bult in method uppercase, forward is a property of forward do lowercase
    }
    //on collisions function is a special function that makes the bullet more dynamic than just moving forward
    //gets bullet to get destroy when colliding with wall/enemy object
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            //destroys the enemy object
        }
        // on collision, bulets will be destroyed
        Destroy(gameObject);
    }
}
