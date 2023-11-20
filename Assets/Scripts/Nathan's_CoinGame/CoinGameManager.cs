using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGameManager : BasedGameManager
{
    protected override void CheckGameOverCondition()
    {
        // this example, we have to be the first person to reach the goal of 10 coins.
        if (playersReachedGoal.Count >0)
        {
            GameOver();
        }
    }

}
