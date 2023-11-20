using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasedGameManager : MonoBehaviour
{
    [SerializeField] protected PlayerInputManager manager;

    [SerializeField] protected int playerSelectWaitTime = 5;
    [SerializeField] protected int playerInstructionalMessageTime = 2;
    [SerializeField] protected List<Transform> spawnPoints = new List<Transform>();
    protected int maxNumberOfPlayers;
    protected Coroutine startJoinRoutine;
    protected Coroutine gameOverRoutine;
    protected Coroutine waitingForJoinRoutine;

    protected List<Transform> allPlayers = new List<Transform>();

    protected List<Transform> playersReachedGoal = new List<Transform>();

    [SerializeField] protected string playerInstruction = "Press A To Crouch";

    protected Transform winningPlayer;

    protected virtual void OnEnable()
    {
        manager.onPlayerJoined += Manager_onPlayerJoined;
        GameEvents.PlayerReachWinCondition += AddPlayerToGoalReached;
        GameEvents.EndGameCheck += CheckGameOverCondition;
    }

    protected virtual void OnDisable()
    {
        manager.onPlayerJoined -= Manager_onPlayerJoined;
        GameEvents.PlayerReachWinCondition -= AddPlayerToGoalReached;
        GameEvents.EndGameCheck -= CheckGameOverCondition;
    }

    protected virtual void Awake()
    {
        maxNumberOfPlayers = spawnPoints.Count;
    }

    protected virtual void Start()
    {
        startJoinRoutine = StartCoroutine(StartJoinProcess());
    }

    protected virtual IEnumerator StartJoinProcess()
    {
        // show on the screen here Press Start to join.

        // wait for 5 seconds.
        int seconds = 0;
        while(seconds < playerSelectWaitTime)
        {
          
            // show the number on the screen.
            seconds++;
            GameEvents.PlayerSelectTextUpdated?.Invoke("Time Till Start: " + (playerSelectWaitTime - seconds));
            yield return new WaitForSeconds(1);
        }
        GameEvents.PlayerSelectTextUpdated?.Invoke("Game Starting!");
        // give one more second grace period.
        yield return new WaitForSeconds(1);
        // then show start and allow player movement and enable the player movement.  
        manager.DisableJoining();
        // invoke event here to send out a message to enable input.
        GameEvents.GameStarted?.Invoke();

        // here if our spawn points haven't been used, then no players joined.
        if(manager.playerCount <=0)
        {
            // jump back to the main menu
            GameEvents.LoadScene?.Invoke(0);
        }

        GameEvents.InstructionalTextUpdated?.Invoke(playerInstruction);

        // show our messagge, then hide it.
        yield return new WaitForSeconds(playerInstructionalMessageTime);
        GameEvents.InstructionalTextUpdated?.Invoke(string.Empty);

        startJoinRoutine = null;
    }

    protected virtual void GameOver()
    {
        // get the placings vs getting the number in the list of players.
        gameOverRoutine = StartCoroutine(GameOverProcess());
    }

    protected virtual IEnumerator GameOverProcess()
    {
        // show the winner playr
        yield return new WaitForSeconds(1);

        // this shouts out to all the players to tell the Ui who won.
        GameEvents.GameOver?.Invoke();

        // wait 5 seconds to go back to the main
        yield return new WaitForSeconds(5);
        // go back to main menu
        GameEvents.LoadScene?.Invoke(0);
        gameOverRoutine = null;
    }

    protected virtual void Manager_onPlayerJoined(PlayerInput obj)
    {
        // spawn the character, remove the spawn point.
        obj.transform.position = spawnPoints[0].position;

        // keep track of how many players we have here, we'll need to know later to handle the game over logic i.e to show winning screen.
        allPlayers.Add(obj.transform);

        // best practice when starting a coroutine is to store it somewhere to access or keep track of, remember each time you start a coroutine, its a new instance of those instructions.
        // Here I need to this to be able to wait for one frame, this fixes a bug where the player doesn't get their number due to an execution order.
        // given it's one frame it happens so fast you'd never see it.
        waitingForJoinRoutine = StartCoroutine(WaitForJoin(obj.transform));
    }

    protected virtual IEnumerator WaitForJoin(Transform player)
    {
        yield return new WaitForEndOfFrame();

        // so here, we grab max num i.e. 4, take the current count i.e. 4, then add 1,
        // so player one would be (4-4) + 1 = 1.
        // player two would be, (4-3) + 1 = 2. this is cause we removed the spawn point from player one.
        int getPlayerNumber = (maxNumberOfPlayers - spawnPoints.Count) + 1;

        // so here because the player number enum is set up to equal a number i.e. playerOne = 1;
        // I can cast our int, as the enum type, i.e. convert it to an enumerated value.
        PlayerNumbers currentPlayer = (PlayerNumbers)getPlayerNumber;

        //Debug.Log(currentPlayer.ToString());

        // invoke the event, to let the player know their number
        GameEvents.OnPlayerJoin?.Invoke(currentPlayer, player);

        // remove the spawn point from the possible choices.
        spawnPoints.RemoveAt(0);

        // setting the routine to null cause it's done.
        waitingForJoinRoutine = null;
    }

    protected virtual void AddPlayerToGoalReached(Transform actor)
    {
        // check to see we haven't already reached the end point.
        if (!playersReachedGoal.Contains(actor))
        {
            playersReachedGoal.Add(actor);

            // pass in the transform of the player then the count of the list, i.e. first player enters count = 1 therefore they placed first.
            GameEvents.PlacementEvent?.Invoke(actor, playersReachedGoal.Count);
            // run the event to check if the game should end.
            GameEvents.EndGameCheck?.Invoke();
        }
    }

    protected virtual void CheckGameOverCondition()
    {
        // here we want to check to see if we have reached our overall win condition
    }
}
