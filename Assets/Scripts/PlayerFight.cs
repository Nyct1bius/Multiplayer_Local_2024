using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{

    PersonagemStatus status;
    public Personagem2Status status2;

    [SerializeField]
    BossStatus boss;

    [SerializeField]
    BattleManager battleManager;
    
    [SerializeField]
    TurnManager turnManager;
    void Start()
    {
        status = GetComponent<PersonagemStatus>();
        turnManager = FindAnyObjectByType<TurnManager>();
        boss = FindAnyObjectByType<BossStatus>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if(turnManager._player1Turn)
        {
            Debug.Log("player1 turn");
            if(Input.GetMouseButtonDown(0))
            {
                boss.ReciveDamage(status._damage, false, true);
                turnManager._player1Turn = false;
                turnManager._player2Turn = true;
            }
        }*/
    }

    public void NormalAttack()
    {
        float damage = 300;

        boss.ReciveDamage(status._damage + damage, false, true);

        // usar attack normal recupera um pouco de sp
        status._currentSP += 50;
        

        turnManager._player1Turn = false;
        turnManager._player2Turn = true;
    }

    public void Defender()
    {
        // Aumenta a defesa ate a proxima rodada e recupera mais SP
        status._currentSP += 100;
        

        turnManager._player1Turn = false;
        turnManager._player2Turn = true;
    }

    public void SpAttack1()
    {
        float damage = 500;
        Debug.Log("SpAttack sp: " + status._currentSP);

        if(status._currentSP >= 50)
        {
            boss.ReciveDamage(status._spDamage + damage, true, true);

            // diminuir sp
            status._currentSP -= 50;
            // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

            turnManager._player1Turn = false;
            turnManager._player2Turn = true;
        }
    }

    public void SpAttack2()
    {
        float damage = 1000;

        if (status._currentSP >= 100)
        {
            boss.ReciveDamage(status._spDamage + damage, true, true);

            // diminuir sp
            status._currentSP -= 100;
            
            // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

            turnManager._player1Turn = false;
            turnManager._player2Turn = true;
        }
    }

    public void SpAttack3()
    {
        float damage = 2000;

        if (status._currentSP >= 150)
        {
            boss.ReciveDamage(status._spDamage + damage, true, true);

            // diminuir sp
            status._currentSP -= 150;
            
            // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

            turnManager._player1Turn = false;
            turnManager._player2Turn = true;
        }
    }
}
