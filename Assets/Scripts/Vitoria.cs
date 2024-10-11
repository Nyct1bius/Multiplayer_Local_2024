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

    public TextMeshProUGUI TdDamageText1;
    public TextMeshProUGUI TdDamageText2;

    [SerializeField]
    AudioManager _audioManager;

    public bool _calculado = false;

    // Start is called before the first frame update
    void Start()
    {
        BattleManager = FindAnyObjectByType<BattleManager>();
        GameManager = FindAnyObjectByType<GameManager>();
        PersonagemStatus = FindAnyObjectByType<PersonagemStatus>();
        Personagem2Status = FindAnyObjectByType<Personagem2Status>();
        _audioManager = FindAnyObjectByType<AudioManager>();

        StatusToText();

        if (!_calculado)
        {
            CalculoTD();
        }

        PlusStatusToText();

        if(GameManager._stage <= 2)
        {
            GameManager._stage++;
            PlayerPrefs.SetInt("Stage", GameManager._stage);
        }

        if(GameManager._stage > 2)
        {
            Fim();
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* StatusToText();

        if (!_calculado)
        {
            CalculoTD();
        }

        PlusStatusToText();*/
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

        if (BattleManager._player1TD > BattleManager._player2TD)
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
        else if (BattleManager._player2TD > BattleManager._player1TD)
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
        PlayerPrefs.SetFloat("Player1SP", PersonagemStatus._sp);
        PlayerPrefs.SetFloat("Player1Damage", PersonagemStatus._damage);
        PlayerPrefs.SetFloat("Player1Defense", PersonagemStatus._defense);
        PlayerPrefs.SetFloat("Player1spDamage", PersonagemStatus._spDamage);
        PlayerPrefs.SetFloat("Player1spDefense", PersonagemStatus._spDefense);

        // player2
        PlayerPrefs.SetFloat("Player2Life", Personagem2Status._life);
        PlayerPrefs.SetFloat("Player2SP", Personagem2Status._sp);
        PlayerPrefs.SetFloat("Player2Damage", Personagem2Status._damage);
        PlayerPrefs.SetFloat("Player2Defense", Personagem2Status._defense);
        PlayerPrefs.SetFloat("Player2spDamage", Personagem2Status._spDamage);
        PlayerPrefs.SetFloat("Player2spDefense", Personagem2Status._spDefense);
    }

    void StatusToText()
    {
        // player1
        TdDamageText1.text = BattleManager._player1TD.ToString();
        HpText.text = PersonagemStatus._life.ToString();
        AtkText.text = PersonagemStatus._damage.ToString();
        DefText.text = PersonagemStatus._defense.ToString();
        SpAtkText.text = PersonagemStatus._spDamage.ToString();
        SpDefText.text = PersonagemStatus._spDefense.ToString();

        // player2
        TdDamageText2.text = BattleManager._player2TD.ToString();
        HpText2.text = Personagem2Status._life.ToString();
        AtkText2.text = Personagem2Status._damage.ToString();
        DefText2.text = Personagem2Status._defense.ToString();
        SpAtkText2.text = Personagem2Status._spDamage.ToString();
        SpDefText2.text = Personagem2Status._spDefense.ToString();
    }

    void PlusStatusToText()
    {
        // player1
        PlusHpText.text = PersonagemStatus._life.ToString();
        PlusAtkText.text = PersonagemStatus._damage.ToString();
        PlusDefText.text = PersonagemStatus._defense.ToString();
        PlusSpAtkText.text = PersonagemStatus._spDamage.ToString();
        PlusSpDefText.text = PersonagemStatus._spDefense.ToString();

        // player2
        PlusHpText2.text = Personagem2Status._life.ToString();
        PlusAtkText2.text = Personagem2Status._damage.ToString();
        PlusDefText2.text = Personagem2Status._defense.ToString();
        PlusSpAtkText2.text = Personagem2Status._spDamage.ToString();
        PlusSpDefText2.text = Personagem2Status._spDefense.ToString();
    }

    void ResetaStatus()
    {
        // player1
        PlayerPrefs.SetFloat("Player1Life", 1000);
        PlayerPrefs.SetFloat("Player1Damage", 350);
        PlayerPrefs.SetFloat("Player1Defense", 5);
        PlayerPrefs.SetFloat("Player1spDamage", 500);
        PlayerPrefs.SetFloat("Player1spDefense", 6);

        // player2
        PlayerPrefs.SetFloat("Player2Life", 1000);
        PlayerPrefs.SetFloat("Player2Damage", 350);
        PlayerPrefs.SetFloat("Player2Defense", 5);
        PlayerPrefs.SetFloat("Player2spDamage", 500);
        PlayerPrefs.SetFloat("Player2spDefense", 6);
    }

    public void Fim()
    {
        // se stage for 3 reinicia o jogo 
        ResetaStatus();
        GameManager._stage = 0;
        PlayerPrefs.SetInt("Stage", GameManager._stage);
    }

    public void Voltar()
    {
        _audioManager.PlaySFX(_audioManager.botao);
        SceneManager.LoadScene("Hub_World");
    }

    public void Continuar()
    {
        _audioManager.PlaySFX(_audioManager.botao);
        SceneManager.LoadScene("TestesM");
    }
}
