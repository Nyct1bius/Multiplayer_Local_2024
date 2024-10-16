using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem2Status : MonoBehaviour
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
    public float _damage = 250;
    public float _defense = 5;
    public float _spDamage = 400;
    public float _spDefense = 6;
    public float _moveArea; // quantos tiles pode mover por rodada 

    private float _blessingEfect;
    private float _curseEfect;

    public float _currentLife;
    public float _currentSP;
    public float _player2TD;

    [SerializeField]
    Player2Fight myPlayer;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        battleManager = FindAnyObjectByType<BattleManager>();

        _life = PlayerPrefs.GetFloat("Player2Life");
        _sp = PlayerPrefs.GetFloat("Player2SP");
        _damage = PlayerPrefs.GetFloat("Player2Damage");
        _defense = PlayerPrefs.GetFloat("Player2Defense");
        _spDamage = PlayerPrefs.GetFloat("Player2spDamage");
        _spDefense = PlayerPrefs.GetFloat("Player2spDefense");

        if (_life == 0) // primeira batalha
        {
            _life = 1000;
            _sp = 500;
            _damage = 350;
            _defense = 5;
            _spDamage = 500;
            _spDefense = 6;
        }

        if (_sp == 0)
        {
            _sp = 500;
        }

        _currentLife = _life;
        _currentSP = _sp;
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

        if (_blessingEfect > 0)
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
        if (magic)
        {
            damage /= _spDefense;
            _currentLife -= damage;

            if (!boss)
            {
                battleManager._player1TD += damage;
            }
        }
        else
        {
            damage /= _defense;
            _currentLife -= damage;

            if (!boss)
            {
                battleManager._player1TD += damage;
            }
        }

        myPlayer.tookDamage = true;
    }
}
