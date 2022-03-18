using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        prep,
        pick,
        fight,
        result,
        victory
    }

    public GameState gState;

    public GameObject prefab;
    public TextBox textBox;

    private string message;
    private bool simulate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(simulate)
        {
            simulate = false;
            switch (gState)
            {
                case GameState.prep:
                    message = "Preparing...";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.pick));
                    break;
                case GameState.pick:
                    message = "Picking fighters";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.fight));
                    break;
                case GameState.fight:
                    //brief 2 hint
                    //if(RandomFighterA.Stats.Health > 0 && RandomFighterB.Stats.Health > 0)
                    //both are alive, keepm fighting
                    //else one of them is dead, check which one, and print the winner to the results
                    //might be good to set message to be the attacks and health.
                    //A tip: message = "some random info" then call SendMessage so you can then send another
                    //line by setting message = "new info" again.
                    //you can put as many phases as you like, consider how much code you're writing
                    if (Random.Range(1,20) >= 15)
                    {
                        message = "Fight has ended";
                        StartCoroutine(TransitionTimer(2f, GameState.result));
                    }
                    else 
                    {
                        message = "Fighting...";
                        StartCoroutine(TransitionTimer(2f, GameState.fight));
                    }
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    break;
                case GameState.result:
                    message = "Results are in!";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.victory));
                    break;
                case GameState.victory:
                    message = "And the winner is...";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    break;
            }
        }
        
    }
    //waits for ... seconds then goes to new state
    IEnumerator TransitionTimer(float delay, GameState newState)
    {
        yield return new WaitForSeconds(delay);
        gState = newState;
        simulate = true;
    }
}
