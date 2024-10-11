using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float launchForce;

    [SerializeField]
    GameObject boss, bossChosenTarget;

    [SerializeField]
    BossAI bossAI;

    private void Awake()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");

        bossAI = boss.GetComponent<BossAI>();   

        bossChosenTarget = bossAI.chosenTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(bossChosenTarget.transform.position * launchForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
