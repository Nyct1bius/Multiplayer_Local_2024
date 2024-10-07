using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubStairs : MonoBehaviour
{
    [SerializeField] private bool isUpCollider, isDownCollider;

    [SerializeField] private GameObject upTeleport, downTeleport;

    private void OnTriggerEnter(Collider other)
    {
        if (isUpCollider && other.tag == "Player")
        {
            other.transform.position = upTeleport.transform.position;
        }
        
        if (isDownCollider && other.tag == "Player")
        {
            other.transform.position = downTeleport.transform.position;
        }

        Debug.Log("Player entered");
    }
}
