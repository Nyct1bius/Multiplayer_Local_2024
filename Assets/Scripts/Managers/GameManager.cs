using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    
    public int _stage = 0; // quando chegar no 3 reinicia o jogo
    // Start is called before the first frame update
    void Start()
    {
        _stage = PlayerPrefs.GetInt("Stage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
