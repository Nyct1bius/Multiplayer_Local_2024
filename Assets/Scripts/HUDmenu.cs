using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDmenu : MonoBehaviour
{

    public GameObject _statusBox1;
    public GameObject _statusBox2;
    public GameObject _tutorialScreen;


    [Header("Player1")]
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI SpAtkText;
    public TextMeshProUGUI SpDefText;
    public TextMeshProUGUI _lifeBarText;
    public TextMeshProUGUI _spBarText;

    [Header("Player2")]
    public TextMeshProUGUI HpText2;
    public TextMeshProUGUI AtkText2;
    public TextMeshProUGUI DefText2;
    public TextMeshProUGUI SpAtkText2;
    public TextMeshProUGUI SpDefText2;
    public TextMeshProUGUI _lifeBarText2;
    public TextMeshProUGUI _spBarText2;

    // player1
    float _life = 1000;
    float _sp = 500;
    float _damage = 350;
    float _defense = 100;
    float _spDamage = 500;
    float _spDefense = 150;

    //player2
    float _life2 = 1000;
    float _sp2 = 500;
    float _damage2 = 350;
    float _defense2 = 100;
    float _spDamage2 = 500;
    float _spDefense2 = 150;

    void Start()
    {
        // Verifica se é a primeira vez que o jogador entra no jogo
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            _tutorialScreen.SetActive(true);

            // Define a chave "FirstTime" para que saibamos que o jogador já entrou no jogo antes
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            // Não é a primeira vez que o jogador entra no jogo
            Debug.Log("veteran player");
            // Você pode continuar normalmente
        }
    }


    public void StatusShow()
    {

        GetSavedStatus();

        _statusBox1.SetActive(true);
        _statusBox2.SetActive(true);

        //player1
        HpText.text = _life.ToString();
        _lifeBarText.text = _life.ToString();
        AtkText.text = _damage.ToString();
        DefText.text = _defense.ToString();
        SpAtkText.text = _spDamage.ToString();
        SpDefText.text = _spDefense.ToString();
        _spBarText.text = _sp.ToString();

        //player2
        HpText2.text = _life2.ToString();
        _lifeBarText2.text = _life2.ToString();
        AtkText2.text = _damage2.ToString();
        DefText2.text = _defense2.ToString();
        SpAtkText2.text = _spDamage2.ToString();
        SpDefText2.text = _spDefense2.ToString();
        _spBarText2.text = _sp2.ToString();
    }

    void GetSavedStatus()
    {
        // player1
        _life = PlayerPrefs.GetFloat("Player1Life");
        _sp = PlayerPrefs.GetFloat("Player1SP");
        _damage = PlayerPrefs.GetFloat("Player1Damage");
        _defense = PlayerPrefs.GetFloat("Player1Defense");
        _spDamage = PlayerPrefs.GetFloat("Player1spDamage");
        _spDefense = PlayerPrefs.GetFloat("Player1spDefense");

        //player2
        _life2 = PlayerPrefs.GetFloat("Player2Life");
        _sp2 = PlayerPrefs.GetFloat("Player2SP");
        _damage2 = PlayerPrefs.GetFloat("Player2Damage");
        _defense2 = PlayerPrefs.GetFloat("Player2Defense");
        _spDamage2 = PlayerPrefs.GetFloat("Player2spDamage");
        _spDefense2 = PlayerPrefs.GetFloat("Player2spDefense");

        if(_life == 0)
        {
             _life = 1000;
             _sp = 500;
             _damage = 350;
             _defense = 100;
             _spDamage = 500;
             _spDefense = 150;

            //player2
             _life2 = 1000;
             _sp2 = 500;
             _damage2 = 350;
             _defense2 = 100;
             _spDamage2 = 500;
             _spDefense2 = 150;
        }
    }

    public void SairGame()
    {
        Application.Quit();
    }
}
