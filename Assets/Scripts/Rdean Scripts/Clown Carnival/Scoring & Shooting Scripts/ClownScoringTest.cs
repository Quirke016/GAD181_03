using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownScoringTest : MonoBehaviour
{

    public ScoringSystem scoringSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            scoringSystem.scoreCount += 1;
            Destroy(other.gameObject);
            Debug.Log("Score updated");
        }
    }
}
