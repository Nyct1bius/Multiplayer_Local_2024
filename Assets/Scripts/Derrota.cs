using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desistir()
    {
        SceneManager.LoadScene("");
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("TestesM");
    }
}
