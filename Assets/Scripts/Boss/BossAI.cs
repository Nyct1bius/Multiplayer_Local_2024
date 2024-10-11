using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public TurnManager turnManager;
    public BattleManager battleManager;
    
    private enum State
    {
        WaitingForTurn,
        MyTurn,
        Dead
    }
    private State state;

    public GameObject player1, player2, chosenTarget;

    public PersonagemStatus status;
    public Personagem2Status status2;

    [SerializeField]
    private float maxMeleeDistance, maxAttackDelay;
    private float attackDelay;

    public Animator anim;

    [SerializeField]
    private GameObject meleeHitbox, projectile, projectileSpawn1, projectileSpawn2;

    [SerializeField]
    private bool targetWasChosen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.WaitingForTurn:
                attackDelay = maxAttackDelay;

                if (turnManager._bossTurn)
                {
                    state = State.MyTurn;
                }

                Debug.Log("Waiting");
                break;

            case State.MyTurn:
                if (!targetWasChosen)
                {
                    ChooseTarget(Random.Range(0, 2));
                }

                if (attackDelay <= 0)
                {
                    transform.LookAt(chosenTarget.transform.position);
                    
                    if (Vector3.Distance(transform.position, chosenTarget.transform.position) <= maxMeleeDistance)
                    {
                        MeleeAttack();   
                    }
                    else
                    {
                        RangedAttack();
                    }

                    state = State.WaitingForTurn;

                    battleManager.EndTurn();

                    targetWasChosen = false;
                }
                else
                {
                    attackDelay -= Time.deltaTime;
                }

                Debug.Log("MyTurn");
                break;

            case State.Dead:
                anim.SetBool("Idle", false);
                anim.SetBool("Dead", true);
                break;
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

        targetWasChosen = true;
    }

    private void MeleeAttack()
    {
        anim.SetTrigger("Melee");

        float damage = 500;

        if (Vector3.Distance(transform.position, player1.transform.position) <= maxMeleeDistance)
        {
            status.ReciveDamage(status._spDamage + damage, true, true);
        }
        if (Vector3.Distance(transform.position, player2.transform.position) <= maxMeleeDistance)
        {
            status2.ReciveDamage(status._spDamage + damage, true, true);
        }
    }

    private void RangedAttack()
    {
        anim.SetTrigger("Ranged");

        Instantiate(projectile, projectileSpawn1.transform.position, Quaternion.identity);
        Instantiate(projectile, projectileSpawn2.transform.position, Quaternion.identity); 
    }
}
