using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public GameManager BattleManager;
    
    private enum State
    {
        WaitingForTurn,
        MyTurn,
        Dead
    }
    private State state;

    [SerializeField] private float health;

    public GameObject player1, player2;

    private GameObject chosenTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.WaitingForTurn:
                Debug.Log("Chefao esperando vez");
                break;
            case State.MyTurn:
                Debug.Log("Vez do chefao");
                ChooseTarget(Random.Range(0, 2));
                transform.LookAt(chosenTarget.transform.position);
                break;
            case State.Dead:
                Debug.Log("Chfao morto");
                break;
        }
    }

    //Verifica e muda o estado atual da AI
    private void CheckForNewState()
    {
        if (health <= 0)
        {
            state = State.Dead;
        }
        else
        {
            
        }
    }

    private void ChooseTarget(float playerDice)
    {
        if (playerDice == 0)
        {
            chosenTarget = player1;
        }
        if (playerDice == 1)
        {
            chosenTarget = player2;
        }
    }
}
