using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    [SerializeField]
    GameObject _statusUI;

    [SerializeField]
    TurnManager _turnManager;

    [SerializeField]
    PersonagemStatus _status;

    [SerializeField]
    Personagem2Status _status2;

    public float _player1TD = 0; // total damage
    public float _player2TD = 0;

    public TextMeshProUGUI NameText;

    [Header("StatusText")]
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI SpAtkText;
    public TextMeshProUGUI SpDefText;

    public GameObject _attackBox1;
    public GameObject _attackBox2;
    public GameObject _closeButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cria um raio da posi��o da c�mera at� a posi��o do mouse na tela
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Faz o Raycast e verifica se colidiu com algo
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o objeto clicado tem o componente espec�fico, por exemplo "Player"
                if (hit.transform.CompareTag("Player") && _turnManager._player1Turn)
                {
                    Debug.Log("Jogador clicado: " + hit.transform.name);
                    Player1Status();
                    _statusUI.SetActive(true);
                    _closeButton.SetActive(true);
                    _attackBox2.SetActive(false);
                    _attackBox1.SetActive(true);
                }
                else if(hit.transform.CompareTag("Player2") && _turnManager._player2Turn)
                {
                    Player2Status();
                    _statusUI.SetActive(true);
                    _closeButton.SetActive(true);
                    _attackBox1.SetActive(false);
                    _attackBox2.SetActive(true);
                }
            }
        }
    }

    void Fim()
    {

    }

    void Player1Status()
    {
        NameText.text = _status._name.ToString();
        HpText.text = _status._life.ToString();
        AtkText.text = _status._damage.ToString();
        DefText.text = _status._defense.ToString();
        SpAtkText.text = _status._spDamage.ToString();
        SpDefText.text = _status._spDefense.ToString();
    }

    void Player2Status()
    {
        NameText.text = _status2._name;
        HpText.text = _status2._life.ToString();
        AtkText.text = _status2._damage.ToString();
        DefText.text = _status2._defense.ToString();
        SpAtkText.text = _status2._spDamage.ToString();
        SpDefText.text = _status2._spDefense.ToString();
    }

    public void SairGame()
    {
        
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("");
    }

    public void Vitoria()
    {
        SceneManager.LoadScene("Vitoria", LoadSceneMode.Additive);
    }

    public void Derrota()
    {
        SceneManager.LoadScene("Derrota", LoadSceneMode.Additive);
    }
}
