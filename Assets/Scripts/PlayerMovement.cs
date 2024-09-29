using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    PlayerCustomActions input;
    NavMeshAgent agent;
    Animator animator;

    [SerializeField] LayerMask clickableLayers;

    [SerializeField] private float lookRotationSpeed;

    [SerializeField] private GameObject originPoint;

    private State state;
    private enum State
    {
        WaitingForAction,
        WaitingForTurn
    }

    public bool isPlayer1, isPlayer2;   

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        input = new PlayerCustomActions();

        AssignInputs();
    }

    private void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();

        Instantiate(originPoint, transform.position, Quaternion.identity);
    }

    private void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 999, clickableLayers))
        {
            if (Vector3.Distance(transform.position, originPoint.transform.position) <= 10)
            {
                agent.destination = hit.point;
            }
            else
            {
                agent.ResetPath();
            }
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();    
    }
}
