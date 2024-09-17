using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private int _stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Stage", _stage);
    }

    public void LoadGame()
    {
        _stage = PlayerPrefs.GetInt("Stage");
    }
}
