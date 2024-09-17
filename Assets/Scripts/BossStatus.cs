using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    
    public string _name;

    public float _life;
    public float _damage;
    public float _defense;
    public float _magicDamage;
    public float _magicDefense;

    public float _currentLife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReciveDamage(float damage, bool magic)
    {
        if (magic)
        {
            damage /= _magicDefense;
            _life -= damage;
        }
        else
        {
            damage /= _defense;
            _life -= damage;
        }
    }
}
