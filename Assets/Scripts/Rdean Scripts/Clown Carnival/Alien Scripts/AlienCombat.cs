using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienCombat : MonoBehaviour
{


// reference to the combat stats manager script

public CombatStatsManager playerAtm;
public CombatStatsManager enemyAtm;

      

    private void OnTriggerEnter2D(Collider2D col) //  on trigger function that deals damage to the player and destroys the alien upon contact
    
        {
            if(transform.position.y<=0)
            
            {
            Destroy(this.gameObject); // destroys game object if its less than or equal to 0 on the y axis

            Debug.Log("Destroyed"); // Debugs to let us know the object is destroyed

            playerAtm = col.gameObject.GetComponent<CombatStatsManager>(); // the player attack manager where if the object has the combat stats manager script attached it executes the code
            if(playerAtm != null)
            {
            playerAtm.TakeDmg(1); // Deals 1 damage to players when the alien hits them
            playerAtm.PlayerDeath(); // Calls the player death function when hit to check if the players health is less than or equal to 0
            Debug.Log("Player takes damage"); //  Debugs the player taking damage
            }
            
            else if(col.gameObject.name != "DestroyBottom") // Debug log to check to see if the player is the one taking damage
            {
                Debug.Log("Error player atm null name of object is " + col.gameObject.name);
            
            }

            
            }
                

            
             
    }



}
