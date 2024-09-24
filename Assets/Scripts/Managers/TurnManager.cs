using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    [SerializeField]
    PlayerFight PlayerFight;

    public bool _player1Turn = true;
    public bool _player2Turn = false; 
    public bool _bossTurn = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerFight = FindAnyObjectByType<PlayerFight>();

        _player1Turn = true;
        _player2Turn = false;
        _bossTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
