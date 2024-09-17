using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{

    public BattleManager BattleManager;
    public GameManager GameManager;
    public PersonagemStatus PersonagemStatus;
    public Personagem2Status Personagem2Status;

    [Header("StatusTextPlayer1")]
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI SpAtkText;
    public TextMeshProUGUI SpDefText;

    [Header("StatusPlusTextPlayer1")]
    public TextMeshProUGUI PlusHpText;
    public TextMeshProUGUI PlusAtkText;
    public TextMeshProUGUI PlusDefText;
    public TextMeshProUGUI PlusSpAtkText;
    public TextMeshProUGUI PlusSpDefText;

    [Header("StatusTextPlayer2")]
    public TextMeshProUGUI HpText2;
    public TextMeshProUGUI AtkText2;
    public TextMeshProUGUI DefText2;
    public TextMeshProUGUI SpAtkText2;
    public TextMeshProUGUI SpDefText2;

    [Header("StatusPlusTextPlayer2")]
    public TextMeshProUGUI PlusHpText2;
    public TextMeshProUGUI PlusAtkText2;
    public TextMeshProUGUI PlusDefText2;
    public TextMeshProUGUI PlusSpAtkText2;
    public TextMeshProUGUI PlusSpDefText2;

    public float _player1TD;
    public float _player2TD;

    public bool _calculado = false;

    // Start is called before the first frame update
    void Start()
    {
        BattleManager = FindAnyObjectByType<BattleManager>();
        GameManager = FindAnyObjectByType<GameManager>();
        PersonagemStatus = FindAnyObjectByType<PersonagemStatus>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!_calculado)
        {
            CalculoTD();
        }
    }

    void CalculoTD()
    {
        if (PersonagemStatus == null)
        {
            PersonagemStatus = FindAnyObjectByType<PersonagemStatus>();
        }

        if (Personagem2Status == null)
        {
            Personagem2Status = FindAnyObjectByType<Personagem2Status>();
        }

        if (_player1TD > _player2TD)
        {
            // buff personagem 1
            if (!PersonagemStatus._blessing[0])
            {
                PersonagemStatus._blessing[0] = true;
            }
            else if (!PersonagemStatus._blessing[1])
            {
                PersonagemStatus._blessing[1] = true;
            }
            else
            {
                PersonagemStatus._blessing[2] = true;
            }

            // debuf personagem 2
            if (!Personagem2Status._curse[0])
            {
                Personagem2Status._curse[0] = true;
            }
            else if (!Personagem2Status._curse[1])
            {
                Personagem2Status._curse[1] = true;
            }
            else
            {
                Personagem2Status._curse[2] = true;
            }

            _calculado = true;
        }
        else if (_player2TD > _player1TD)
        {
            // buff personagem 2
            if (!Personagem2Status._blessing[0])
            {
                Personagem2Status._blessing[0] = true;
            }
            else if (!Personagem2Status._blessing[1])
            {
                Personagem2Status._blessing[1] = true;
            }
            else
            {
                Personagem2Status._blessing[2] = true;
            }

            // debuf personagem 1
            if (!PersonagemStatus._curse[0])
            {
                PersonagemStatus._curse[0] = true;
            }
            else if (!PersonagemStatus._curse[1])
            {
                PersonagemStatus._curse[1] = true;
            }
            else
            {
                PersonagemStatus._curse[2] = true;
            }

            _calculado = true;
        }

        ChangeStatus();
    }

    void ChangeStatus()
    {
        //player 1
        PersonagemStatus.BlessingEfect();
        PersonagemStatus.CurseEfect();
        //player 2
        Personagem2Status.BlessingEfect();
        Personagem2Status.CurseEfect();

        SaveNewStatus();

    }

    void SaveNewStatus()
    {
        // player1
        PlayerPrefs.SetFloat("Player1Life", PersonagemStatus._life);
        PlayerPrefs.SetFloat("Player1Damage", PersonagemStatus._damage);
        PlayerPrefs.SetFloat("Player1Defense", PersonagemStatus._defense);
        PlayerPrefs.SetFloat("Player1spDamage", PersonagemStatus._spDamage);
        PlayerPrefs.SetFloat("Player1spDefense", PersonagemStatus._spDefense);

        // player2
        PlayerPrefs.SetFloat("Player2Life", Personagem2Status._life);
        PlayerPrefs.SetFloat("Player2Damage", Personagem2Status._damage);
        PlayerPrefs.SetFloat("Player2Defense", Personagem2Status._defense);
        PlayerPrefs.SetFloat("Player2spDamage", Personagem2Status._spDamage);
        PlayerPrefs.SetFloat("Player2spDefense", Personagem2Status._spDefense);
    }
}
