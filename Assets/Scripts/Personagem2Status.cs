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
    // status
    public float _life;
    public float _damage;
    public float _defense;
    public float _spDamage;
    public float _spDefense;
    public float _moveArea; // quantos tiles pode mover por rodada 

    private float _blessingEfect;
    private float _curseEfect;

    public float _currentLife;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }


        _life = PlayerPrefs.GetFloat("Player2Life");
        _damage = PlayerPrefs.GetFloat("Player2Damage");
        _defense = PlayerPrefs.GetFloat("Player2Defense");
        _spDamage = PlayerPrefs.GetFloat("Player2spDamage");
        _spDefense = PlayerPrefs.GetFloat("Player2spDefense");

        if (_life == 0) // primeira batalha
        {
            _life = 1000;
            _damage = 350;
            _defense = 100;
            _spDamage = 500;
            _spDefense = 150;
        }

        _currentLife = _life;
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

        _life *= _blessingEfect;
        _damage *= _blessingEfect;
        _defense *= _blessingEfect;
        _spDamage *= _blessingEfect;
        _spDefense *= _blessingEfect;
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

        _life *= _curseEfect;
        _damage *= _curseEfect;
        _defense *= _curseEfect;
        _spDamage *= _curseEfect;
        _spDefense *= _curseEfect;
    }

    public void ReciveDamage(float damage, bool magic)
    {
        if (magic)
        {
            damage /= _spDefense;
            _currentLife -= damage;
        }
        else
        {
            damage /= _defense;
            _currentLife -= damage;
        }
    }
}
