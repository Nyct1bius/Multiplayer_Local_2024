using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemStatus : MonoBehaviour
{
    
    public string _name;

    [SerializeField]
    GameManager gameManager;
    // status
    public int _life;
    public int _damage;
    public int _defense;
    public int _magicDamage;
    public int _magicDefense;
    public int _moveArea; // quantos tiles pode mover por rodada 

    private int _blessingEfect;

    public int _currentLife;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }

        if(gameManager !=  null)
        {
            BlessingEfect();
        }
        
        if(_blessingEfect != 0)
        {
            _life *= _blessingEfect;
            _damage *= _blessingEfect;
            _defense *= _blessingEfect;
            _magicDamage *= _blessingEfect;
            _magicDefense *= _blessingEfect;
        }

        _currentLife = _life;
    }

    void BlessingEfect()
    {
        if (gameManager._blessing[2])
        {
            _blessingEfect = 4;
        }
        else if (gameManager._blessing[1])
        {
            _blessingEfect = 3;
        }
        else if (gameManager._blessing[0])
        {
            _blessingEfect = 2;
        }
    }

    public void ReciveDamage(int damage, bool magic)
    {
        if(magic)
        {
            damage /= _magicDefense;
            _currentLife -= damage;
        }
        else
        {
            damage /= _defense;
            _currentLife -= damage;
        }
    }
}
