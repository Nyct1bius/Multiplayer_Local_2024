using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public TurnManager TurnManager;
    
    private enum State
    {
        WaitingForTurn,
        MyTurn,
        Dead
    }
    private State state;

    public GameObject player1, player2, chosenTarget;

    [SerializeField] private float maxMeleeDistance;

    public bool isAlive = true;

    public Animator anim;

    [SerializeField] private GameObject meleeHitbox, projectileSpawn1, projectileSpawn2;

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
                break;
            case State.MyTurn:
                ChooseTarget(Random.Range(0, 2));
                Attack();
                break;
            case State.Dead:
                isAlive = false;
                anim.SetBool("Dead", true);
                break;
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
    }

    //Verificando a distância do player escolhido, espera um delay e ataca
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1, 3.5f));

        transform.LookAt(chosenTarget.transform.position);

        if (Vector2.Distance(transform.position, chosenTarget.transform.position) <= maxMeleeDistance)
        {
            anim.SetTrigger("Melee");
        }
        else
        {
            anim.SetTrigger("Ranged");
        }
    }

    private IEnumerator MeleeAttack()
    {
        yield return new WaitForSeconds(1.07f);

        meleeHitbox.SetActive(true);
    }

    private IEnumerator RangedAttack()
    {
        yield return new WaitForSeconds(1);


    }
}
