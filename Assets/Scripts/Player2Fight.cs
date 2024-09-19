using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Fight : MonoBehaviour
{
    public PersonagemStatus status;
    public Personagem2Status status2;

    [SerializeField]
    BossStatus boss;

    [SerializeField]
    TurnManager turnManager;
    void Start()
    {
        status2 = GetComponent<Personagem2Status>();
        turnManager = FindAnyObjectByType<TurnManager>();
        boss = FindAnyObjectByType<BossStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if (turnManager._player2Turn)
        {
            Debug.Log("player2 turn");
            if (Input.GetMouseButtonDown(0))
            {
                boss.ReciveDamage(status2._damage, true, false);
                turnManager._player1Turn = true;
                turnManager._player2Turn = false;
            }
        }*/
    }

    public void NormalAttack()
    {
        float damage = 300;

        boss.ReciveDamage(status2._damage + damage, false, false);

        // usar attack normal recupera um pouco de sp

        turnManager._player1Turn = true;
        turnManager._player2Turn = false;
    }

    public void Defender()
    {
        // Aumenta a defesa ate a proxima rodada

        turnManager._player1Turn = true;
        turnManager._player2Turn = false;
    }

    public void SpAttack1()
    {
        float damage = 500;

        boss.ReciveDamage(status2._spDamage + damage, true, false);

        // diminuir sp

        turnManager._player1Turn = true;
        turnManager._player2Turn = false;
    }

    public void SpAttack2()
    {
        float damage = 1000;

        boss.ReciveDamage(status2._spDamage + damage, true, false);

        // diminuir sp

        turnManager._player1Turn = true;
        turnManager._player2Turn = false;
    }

    public void SpAttack3()
    {
        float damage = 2000;

        boss.ReciveDamage(status2._spDamage + damage, true, false);

        // diminuir sp

        turnManager._player1Turn = true;
        turnManager._player2Turn = false;
    }
}
