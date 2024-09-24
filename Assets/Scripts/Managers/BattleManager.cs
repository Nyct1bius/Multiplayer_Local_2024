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

    [SerializeField]
    PlayerFight _playerFight;

    [SerializeField]
    Player2Fight _player2Fight;

    [SerializeField]
    BossStatus _boss;

    [SerializeField]
    HealthBar _healthBar;
    [SerializeField]
    SpecialBar _specialBar;

    public Slider _hpSlider;
    public Slider _spSlider;

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

    public TextMeshProUGUI _lifeBarText;
    public TextMeshProUGUI _spBarText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cria um raio da posição da câmera até a posição do mouse na tela
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Faz o Raycast e verifica se colidiu com algo
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o objeto clicado tem o componente específico, por exemplo "Player"
                if (hit.transform.CompareTag("Player") && _turnManager._player1Turn && !_playerFight.selected)
                {
                    Debug.Log("Jogador clicado: " + hit.transform.name);
                    Player1Status();
                    _statusUI.SetActive(true);
                    _closeButton.SetActive(true);
                    _attackBox2.SetActive(false);
                    _attackBox1.SetActive(true);
                    _healthBar.SetMaxHealth(_status._life);
                    _healthBar.SetHealth(_status._currentLife);
                    _lifeBarText.text = _status._currentLife.ToString();
                    _specialBar.SetMaxSpecial(_status._sp);
                    _specialBar.SetSpecial(_status._currentSP);
                    _spBarText.text = _status._currentSP.ToString();

                }
                else if(hit.transform.CompareTag("Player2") && _turnManager._player2Turn && !_player2Fight.selected)
                {
                    Player2Status();
                    _statusUI.SetActive(true);
                    _closeButton.SetActive(true);
                    _attackBox1.SetActive(false);
                    _attackBox2.SetActive(true);
                    _healthBar.SetMaxHealth(_status2._life);
                    _healthBar.SetHealth(_status2._currentLife);
                    _lifeBarText.text = _status2._currentLife.ToString();
                    _specialBar.SetMaxSpecial(_status2._sp);
                    _specialBar.SetSpecial(_status2._currentSP);
                    _spBarText.text = _status2._currentSP.ToString();
                }
            }
        }

        if (_status._currentLife <= 0 && _status2._currentLife <= 0)
        {
            Derrota();
        }

        if(_boss._currentLife <= 0)
        {
            Vitoria();
        }
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
        Application.Quit();
    }

    public void EndTurn()
    {
        if(_turnManager._player1Turn)
        {
            _turnManager._player1Turn = false;
            _turnManager._bossTurn = false;
            _turnManager._player2Turn = true;
            _playerFight.selected = false;
            _player2Fight.selected = false;
        }
        else if(_turnManager._player2Turn)
        {
            _turnManager._player2Turn = false;
            _turnManager._bossTurn = true;
            _turnManager._player1Turn = false;
            _playerFight.selected = false;
            _player2Fight.selected = false;
        }
        else // boss turn
        {
            _turnManager._player2Turn = false;
            _turnManager._bossTurn = false;
            _turnManager._player1Turn = true;
            _playerFight.selected = false;
            _player2Fight.selected = false;
        }
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
