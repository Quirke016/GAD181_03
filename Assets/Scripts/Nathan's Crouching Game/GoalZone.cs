using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple example of a goal or way to win the game, this could easily be replaced with other logic i.e. when a character collects 10 coins, you can use the same event, 
/// just tell the game when they achieved that goal as it's only passing in the transform of the character, and their placing i.e. 1st, 2nd 3rd..
/// </summary>
public class GoalZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // add the player to the manager, to let them know they reached the goal.
            GameEvents.PlayerReachWinCondition?.Invoke(collision.transform);
        }
    }
}
