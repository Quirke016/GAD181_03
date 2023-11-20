using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingGameManager : BasedGameManager
{
    protected override void CheckGameOverCondition()
    {
        // here we call goal achieved event, if we have a winner or multiple winners.
        if (playersReachedGoal.Count == maxNumberOfPlayers - spawnPoints.Count)
        {
            // so if we have 4 in the goal zone, and 4 -0 spawn points are left, we all reached the goal.
            // if we have 3 players, and placed 3rd, then 4 max - 1 spawn point left, = 3 which is number players in game.
            // the game is over now, cause all players that are in the game have reached the goal, start the game over process
            GameOver();
        }
    }
}
