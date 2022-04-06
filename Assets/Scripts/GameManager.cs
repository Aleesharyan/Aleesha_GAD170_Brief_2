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
        victory,
        checkIfContinue
    }

    public GameState gState;

    public GameObject prefab;
    public TextBox textBox;

    public int teamSize = 3;

    private string message;
    private bool simulate = true;

    private GameObject[] team1;
    private GameObject[] team2;

    private GameObject Fighter1;
    private GameObject Fighter2;

    // Start is called before the first frame update
    void Awake()
    {
        //Setting up teams
        team1 = SetupTeam();
        team2 = SetupTeam();
    }

    // Update is called once per frame
    void Update()
    {
        if (simulate)
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
                    //Here im trying to get it to pick my fighters
                    Fighter1 = PickFightersTeam1;
                    Fighter2 = PickFightersTeam2;
                    StartCoroutine(TransitionTimer(2f, GameState.fight));
                    break;
                case GameState.fight:
                    //if one of the fighters has no health left the fight will end
                    if (Fighter1.health = 0 || Fighter2.health = 0)
                    {
                        message = "Fight has ended";
                        StartCoroutine(TransitionTimer(2f, GameState.result));
                    }
                    else
                    {
                        message = "Fighting...";
                        //the fighters fight
                        if (Random.Range(0, 7) >= 3)
                        {
                            Random.Range(team1).GetComponent<Stats>().Attack;
                            Random.Range(team2).GetComponent<Stats>().health - team1 GetComponent<Stats>().Attack;
                        }
                        else
                        {
                            Random.Range(team2).GetComponent<Stats>().Attack;
                            Random.Range(team1).GetComponent<Stats>().health - team2 GetComponent<Stats>().Attack;
                        }
                        if (uiM != null)
                        {
                            uiM.UpdateBars();
                        }
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
                case GameState.checkIfContinue:
                    //this is when the game checks if there are any fighters left
                    for (int i = 0; i < teamSize; i++)
                    {
                        int killed = 0;
                        if (team1[i].GetComponent<Stats>().health <= 0)
                        {
                            killed++;
                        }
                        if (killed >= teamSize)
                        {
                            Debug.Log("Team 1 as is defeated!");
                            Application.Quit();
                        }
                    }
                    for (int x = 0; x < teamSize; x++)
                    {
                        int killed = 0;
                        if (team2[x].GetComponent<Stats>().health <= 0)
                        {
                            //character is dead
                            killed++;
                        }
                        else
                        {
                            //pick this character to fight
                        }
                        if (killed >= teamSize)
                        {
                            Debug.Log("Team 2 is defeated!");
                            Application.Quit();
                        }

                    }
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

    //Team setup
    private GameObject[] SetupTeam()
    {
        GameObject[] team = new GameObject[teamSize];

        for (int i = 0; i < teamSize; i++)
        {
            team[i] = Instantiate(prefab);
        }

        return team;
    }

    //PIcking the fighters that'll fight
    public GameObject[PickFightersTeam1()] 
    {
        for (int a = 0; a < 1; a++);
        {
            GameObject Fighter1 = team1[Random.Range(0, team1.Length)];
        }
        return Fighter1;
        
    }

    public GameObject[PickFightersTeam2()] 
    {
        for (int a = 0; a < 1; a++);
        {
            GameObject Fighter1 = team1[Random.Range(0, team1.Length)];
        }
        return Fighter2;

    }


}
