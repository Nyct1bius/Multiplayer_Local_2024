using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float launchForce;

    public PersonagemStatus status;
    public Personagem2Status status2;

    [SerializeField]
    GameObject player1, player2, bossChosenTarget;

    [SerializeField]
    BossAI boss;

    private void Awake()
    {
        boss = gameObject.GetComponent<BossAI>();

        bossChosenTarget = boss.chosenTarget;
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

    private void OnTriggerEnter(Collider col)
    {

    }
}
