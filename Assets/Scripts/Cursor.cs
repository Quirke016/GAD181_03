using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = Physics2D.OverlapPoint(transform.position);
        if(col!=null)
        {
            CustomButton button = col.gameObject.GetComponent<CustomButton>();
            if(button != null )
            {
                Debug.Log("OverButton");
            }
        }
    }
}
