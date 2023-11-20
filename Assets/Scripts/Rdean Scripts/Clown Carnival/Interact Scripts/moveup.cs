using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveup : MonoBehaviour
{
    Rigidbody2D rb; // reference that allows us to attach an object in the inspector
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // sets the object to enable rigid body physics 
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce (rb.transform.up * 1.5f); // adds force to the object to enable it to go towards the top of the screen
    }
}
