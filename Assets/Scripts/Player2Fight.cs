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

    public bool selected = false;
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

        if (!selected)
        {
            boss.ReciveDamage(status2._damage + damage, false, false);

            // usar attack normal recupera um pouco de sp
            status2._currentSP += 50; // botar limite

            selected = true;
        }


        /* turnManager._player1Turn = false;
         turnManager._player2Turn = true;*/
    }

    public void Defender()
    {

        if (!selected)
        {
            // Aumenta a defesa ate a proxima rodada e recupera mais SP
            status2._defense *= 2;
            status2._currentSP += 100;

            selected = true;
        }


        /* turnManager._player1Turn = false;
        turnManager._player2Turn = true;*/
    }

    public void SpAttack1()
    {
        float damage = 500;

        if (!selected)
        {
            if (status2._currentSP >= 50)
            {
                boss.ReciveDamage(status2._spDamage + damage, true, false);

                // diminuir sp
                status2._currentSP -= 50;
                // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

                selected = true;
                /* turnManager._player1Turn = false;
                   turnManager._player2Turn = true;*/
            }
        }

    }

    public void SpAttack2()
    {
        float damage = 1000;

        if (!selected)
        {
            if (status2._currentSP >= 100)
            {
                boss.ReciveDamage(status2._spDamage + damage, true, false);

                // diminuir sp
                status2._currentSP -= 100;

                // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

                selected = true;
                /* turnManager._player1Turn = false;
                   turnManager._player2Turn = true;*/
            }
        }
    }

    public void SpAttack3()
    {
        float damage = 2000;

        if (!selected)
        {
            if (status2._currentSP >= 150)
            {
                boss.ReciveDamage(status2._spDamage + damage, true, false);

                // diminuir sp
                status2._currentSP -= 150;

                // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

                selected = true;

                /* turnManager._player1Turn = false;
                   turnManager._player2Turn = true;*/
            }
        }
    }
}
