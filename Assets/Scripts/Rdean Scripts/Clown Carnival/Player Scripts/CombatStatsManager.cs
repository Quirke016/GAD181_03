using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatsManager : MonoBehaviour
{

   public GameManagerScript gameManager; // reference to the game manager script
   public int hp; // health int which will be changed in inspector
   public int atk; // attack int which will be changed in inspector
   private bool isDead; // bool that is used to determine whether or not player is dead
  

   public void TakeDmg(int amount) // function that takes in an amount of damage and makes the health variable = the total from the amount taken away
   {
hp -= amount;
   }

   public void DealDmg(GameObject target) // deal damage function that deals damage if the object interacting with it has the combat stats manager script attatched 
   {
    var atm = target.GetComponent<CombatStatsManager>();
    if (atm != null)
    {
        atm.TakeDmg(atk);
    }
   }


   public void PlayerDeath() // player death function that checks to see if the players health is less than or = to 0 and if the player is not dead, it will then set it to true and debug the game is over
   {
      if(hp <= 0 && !isDead)
      {
         isDead = true;
         Debug.Log("Game Over!");

      }
   }
}
