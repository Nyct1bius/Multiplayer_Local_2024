using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class HubPlayerMovement : MonoBehaviour
{
    PlayerCustomActions input;
    NavMeshAgent agent;

    [SerializeField]
    Animator animator;

    [SerializeField]
    LayerMask clickableLayers;

    [SerializeField]
    GameObject destinationCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        input = new PlayerCustomActions();

        AssignInputs();
    }

    private void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
    }

    private void ClickToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 999, clickableLayers))
        {
            destinationCollider.transform.position = hit.point;

            agent.destination = hit.point;

            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Destination")
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }
}
