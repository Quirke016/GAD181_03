using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyobject : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D col) // on trigger event that destroys any object with a collider that interacts with it to prevent lag from pile up of items
    
        {
            Destroy(col.gameObject);

            Debug.Log("Object destroyed"); // debugs out when the object is destroyed
            
        }


}
