using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{

    [SerializeField]
    AudioManager _audioManager;
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = FindAnyObjectByType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Desistir()
    {
        _audioManager.PlaySFX(_audioManager.botao);
        SceneManager.LoadScene("Hub_World");
    }

    public void Reiniciar()
    {
        _audioManager.PlaySFX(_audioManager.botao);
        SceneManager.LoadScene("TestesM");
    }
}
