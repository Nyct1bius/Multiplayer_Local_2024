using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFight : MonoBehaviour
{
    PlayerCustomActions input;
    NavMeshAgent agent;

    [SerializeField]
    LayerMask clickableLayers;

    [SerializeField]
    GameObject destinationCollider;

    public PersonagemStatus status;
    public Personagem2Status status2;

    [SerializeField]
    BossStatus boss;
    
    [SerializeField]
    TurnManager turnManager;

    [SerializeField]
    Animator animator;

    public bool selected = false, canMove = true;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        input = new PlayerCustomActions();

        AssignInputs();
    }

    void Start()
    {
        status = GetComponent<PersonagemStatus>();
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

    private void AssignInputs()
    {                                      
        input.Main.Move.performed += ctx => ClickToMove();        
    }

    private void ClickToMove()
    {
        if (turnManager._player1Turn && canMove)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 999, clickableLayers))
            {
                destinationCollider.transform.position = hit.point;

                agent.destination = hit.point;
                    
                animator.SetBool("Idle", false);                    
                animator.SetBool("Walk", true);
            }

            canMove = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        float projectileDamage = 100;
        
        if (col.tag == "Destination")
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
        }

        if (col.tag == "Boss Projectile")
        {
            status.ReciveDamage(boss._damage + projectileDamage, true, true);
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    public void NormalAttack()
    {
        float damage = 300;

        if (!selected)
        {
            boss.ReciveDamage(status._damage + damage, false, true);

            animator.SetTrigger("Attack");

            // usar attack normal recupera um pouco de sp
            status._currentSP += 50; // botar limite

            selected = true;
        }
        

       /* turnManager._player1Turn = false;
        turnManager._player2Turn = true;*/
    }

    public void Defender()
    {

        if (!selected)
        {
            animator.SetTrigger("Attack");

            // Aumenta a defesa ate a proxima rodada e recupera mais SP
            status._defense *= 2;
            status._currentSP += 100;

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
            if (status._currentSP >= 50)
            {
                boss.ReciveDamage(status._spDamage + damage, true, true);

                animator.SetTrigger("SuperAttack");

                // diminuir sp
                status._currentSP -= 50;
                // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

                /* turnManager._player1Turn = false;
                   turnManager._player2Turn = true;*/

                selected = true;
            }
        }

    }

    public void SpAttack2()
    {
        float damage = 1000;

        if (!selected)
        {
            if (status._currentSP >= 100)
            {
                boss.ReciveDamage(status._spDamage + damage, true, true);

                animator.SetTrigger("SuperAttack");

                // diminuir sp
                status._currentSP -= 100;

                // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

                /* turnManager._player1Turn = false;
                   turnManager._player2Turn = true;*/

                selected = true;
            }
        }
    }

    public void SpAttack3()
    {
        float damage = 2000;

        if (!selected)
        {
            if (status._currentSP >= 150)
            {
                boss.ReciveDamage(status._spDamage + damage, true, true);

                animator.SetTrigger("SuperAttack");

                // diminuir sp
                status._currentSP -= 150;

                selected = true;

                // se jogador estiver a certa distancia do player 2 o ataque vai pergar o player2 tb

                /* turnManager._player1Turn = false;
                   turnManager._player2Turn = true;*/
            }
        }
    }
}
