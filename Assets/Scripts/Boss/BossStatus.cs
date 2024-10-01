using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    public GameManager GameManager;
    public BattleManager BattleManager;

    public string _name;

    public float _life = 10000f;
    public float _damage = 500f;
    public float _defense = 400f;
    public float _magicDamage = 600f;
    public float _magicDefense = 300f;

    public float _currentLife;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindAnyObjectByType<GameManager>();
        BattleManager = FindAnyObjectByType<BattleManager>();

        if(GameManager._stage > 0)
        {
            UpStatus();
        }
        _currentLife = _life;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void UpStatus()
    {
        if(GameManager._stage == 1)
        {
            _life *= 2f;
            _damage *= 1.2f;
            _defense *= 1.2f;
            _magicDamage *= 1.2f;
            _magicDefense *= 1.2f;
        }
        else if(GameManager._stage == 2)
        {
            _life *= 3f;
            _damage *= 1.6f;
            _defense *= 1.6f;
            _magicDamage *= 1.6f;
            _magicDefense *= 1.6f;
        }
    }

    public void ReciveDamage(float damage, bool magic, bool player1)
    {
        if (magic)
        {
            damage /= _magicDefense;
            _currentLife -= damage;

            if(player1)
            {
                BattleManager._player1TD += damage;
            }else
            {
                BattleManager._player2TD += damage;
            }
        }
        else
        {
            damage /= _defense;
            _currentLife -= damage;

            if (player1)
            {
                BattleManager._player1TD += damage;
            }
            else
            {
                BattleManager._player2TD += damage;
            }
        }
    }
}
