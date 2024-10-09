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

    [SerializeField] private float maxMeleeDistance, attackDelay;

    public Animator anim;

    [SerializeField] private GameObject meleeHitbox, projectile, projectileSpawn1, projectileSpawn2;

    [SerializeField] private bool choseTarget = false;

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
                CheckTurns();

                anim.SetBool("Idle", true);

                attackDelay = 2;
                break;
            case State.MyTurn:
                CheckTurns();

                if (!choseTarget)
                {
                    ChooseTarget(Random.Range(0, 2));
                }

                if (attackDelay <= 0)
                {
                    transform.LookAt(chosenTarget.transform.position);
                    
                    if (Vector3.Distance(transform.position, chosenTarget.transform.position) <= maxMeleeDistance)
                    {
                        anim.SetTrigger("Melee");

                        MeleeAttack();
                    }
                    else
                    {
                        anim.SetTrigger("Ranged");

                        RangedAttack();
                    }
                }
                else
                {
                    attackDelay -= Time.deltaTime;
                }
                break;
            case State.Dead:
                anim.SetBool("Idle", false);
                anim.SetBool("Dead", true);
                break;
        }
    }
    
    //Verifica se é seu turno
    private void CheckTurns()
    {
        if (turnManager._bossTurn)
        {
            state = State.MyTurn;
        }
        else
        {
            state = State.WaitingForTurn;
        }
    }
    
    //Escolhe qual dos jogadores atacar
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

        choseTarget = true;
    }

    private IEnumerator MeleeAttack()
    {
        yield return new WaitForSeconds(1.07f);

        meleeHitbox.SetActive(true);

        choseTarget = false;

        battleManager.EndTurn();
    }

    private IEnumerator RangedAttack()
    {
        yield return new WaitForSeconds(1);

        Instantiate(projectile, projectileSpawn1.transform.position, Quaternion.identity);
        Instantiate(projectile, projectileSpawn2.transform.position, Quaternion.identity);

        choseTarget = false;

        battleManager.EndTurn();
    }
}
