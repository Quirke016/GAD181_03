using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCharacter : BaseCharacterController
{
    [SerializeField] protected int playerCoins;
    [SerializeField] protected int goalCoins = 5;


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            playerCoins++;
            Destroy(collision.gameObject);

            if(playerCoins >= goalCoins)
            {
                GameEvents.PlayerReachWinCondition?.Invoke(transform);
            }
        }
    }
}
