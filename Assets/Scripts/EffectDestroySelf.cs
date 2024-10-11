using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroySelf : MonoBehaviour
{
    [SerializeField]
    private float maxEffectTimer;
    private float effectTimer;

    [SerializeField]
    GameObject myChild;
    
    // Start is called before the first frame update
    void Start()
    {
        effectTimer = maxEffectTimer;
    }

    // Update is called once per frame
    void Update()
    {           
        if (effectTimer <= 0)            
        {                
            myChild.SetActive(true);            
        }            
        else            
        {                
            effectTimer -= Time.deltaTime;            
        }
        
        Destroy(gameObject, 3f);
    }
}
