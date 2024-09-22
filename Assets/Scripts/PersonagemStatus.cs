using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemStatus : MonoBehaviour
{
    
    public string _name;

    public bool[] _blessing;
    public bool[] _curse;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    BattleManager battleManager;
    // status
    public float _life = 1000;
    public float _sp = 500;
    public float _damage = 350;
    public float _defense = 100;
    public float _spDamage = 500;
    public float _spDefense = 150;
    public float _moveArea; // quantos tiles pode mover por rodada 

    private float _blessingEfect;
    private float _curseEfect;

    public float _currentLife;
    public float _currentSP;
    public float _player1TD;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        battleManager = FindAnyObjectByType<BattleManager>();


        _life = PlayerPrefs.GetFloat("Player1Life");
        _sp = PlayerPrefs.GetFloat("Player1SP");
        _damage = PlayerPrefs.GetFloat("Player1Damage");
        _defense = PlayerPrefs.GetFloat("Player1Defense");
        _spDamage = PlayerPrefs.GetFloat("Player1spDamage");
        _spDefense = PlayerPrefs.GetFloat("Player1spDefense");

        if(_life == 0) // primeira batalha
        {
            _life = 1000;
            _sp = 500;
            _damage = 350;
            _defense = 100;
            _spDamage = 500;
            _spDefense = 150;
        }

        if(_sp == 0)
        {
            _sp = 500;
        }

        _currentLife = _life;
        _currentSP = _sp;

        Debug.Log("currentLife on Status: " + _currentLife);
        Debug.Log("SP on Status: " + _sp);
        Debug.Log("currentSp on Status: " + _currentSP);
    }

    public void BlessingEfect()
    {
        if (_blessing[2])
        {
            _blessingEfect = 2.5f;
        }
        else if (_blessing[1])
        {
            _blessingEfect = 2f;
        }
        else if (_blessing[0])
        {
            _blessingEfect = 1.5f;
        }

        if(_blessingEfect > 0)
        {
            _life *= _blessingEfect;
            _sp *= _blessingEfect;
            _damage *= _blessingEfect;
            _defense *= _blessingEfect;
            _spDamage *= _blessingEfect;
            _spDefense *= _blessingEfect;
        }
    }

    public void CurseEfect()
    {
        if (_curse[2])
        {
            _curseEfect = 0.5f;
        }
        else if (_curse[1])
        {
            _curseEfect = 0.7f;
        }
        else if (_curse[0])
        {
            _curseEfect = 0.9f;
        }

        if (_curseEfect > 0)
        {
            _life *= _curseEfect;
            _sp *= _curseEfect;
            _damage *= _curseEfect;
            _defense *= _curseEfect;
            _spDamage *= _curseEfect;
            _spDefense *= _curseEfect;
        }
    }

    public void ReciveDamage(float damage, bool magic, bool boss)
    {
        if(magic)
        {
            damage /= _spDefense;
            _currentLife -= damage;

            if(!boss)
            {
                battleManager._player2TD += damage;
            }
        }
        else
        {
            damage /= _defense;
            _currentLife -= damage;

            if (!boss)
            {
                battleManager._player2TD += damage;
            }
        }

        
    }
}
