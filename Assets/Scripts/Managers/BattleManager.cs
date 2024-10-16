using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

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
    AudioManager _audioManager;

    [SerializeField]
    HealthBar _healthBar;

    [SerializeField]
    HealthBar _bossHealthBar;

    [SerializeField]
    SpecialBar _specialBar;

    public Slider _hpSlider;
    public Slider _spSlider;

    public float _player1TD = 0; // total damage
    public float _player2TD = 0;

    public bool _isVictory = false;

    public TextMeshProUGUI NameText;

    [Header("StatusText")]
    public Image _perfilImage;
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

    public Sprite[] PerfilImages;

    private float victoryTimer = 4;

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

            _bossHealthBar.SetMaxHealth(_boss._life);
            _bossHealthBar.SetHealth(_boss._currentLife);

            // Faz o Raycast e verifica se colidiu com algo
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o objeto clicado tem o componente espec�fico, por exemplo "Player"
                if (hit.transform.CompareTag("Player") && _turnManager._player1Turn && !_playerFight.selected && _status._currentLife > 0)
                {
                    //Debug.Log("Jogador clicado: " + hit.transform.name);
                    Player1Status();
                    _perfilImage.sprite = PerfilImages[0];
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
                else if(hit.transform.CompareTag("Player2") && _turnManager._player2Turn && !_player2Fight.selected && _status2._currentLife > 0)
                {
                    Player2Status();
                    _perfilImage.sprite = PerfilImages[1];
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
            Debug.Log("player 2 turn ");
            _turnManager._player1Turn = false;
            _turnManager._bossTurn = false;
            _turnManager._player2Turn = true;
            _playerFight.selected = false;
            _player2Fight.selected = false;
            _playerFight.canMove = true;

            if(_status2._currentLife <= 0)
            {
                EndTurn();
            }
        }
        else if(_turnManager._player2Turn)
        {
            Debug.Log("Boss turn ");
            _turnManager._player2Turn = false;
            _turnManager._bossTurn = true;
            _turnManager._player1Turn = false;
            _playerFight.selected = false;
            _player2Fight.selected = false;
            _player2Fight.canMove = true;
        }
        else// player1 turn
        {
            Debug.Log("Player 1 turn ");
            _turnManager._player2Turn = false;
            _turnManager._bossTurn = false;
            _turnManager._player1Turn = true;
            _playerFight.selected = false;
            _player2Fight.selected = false;

            if (_status._currentLife <= 0)
            {
                EndTurn();
            }
        }
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("Hub_World");
    }

    public void Vitoria()
    {
        if(!_isVictory)
        {
            if (victoryTimer <= 0)
            {
                SceneManager.LoadScene("Vitoria", LoadSceneMode.Additive);
                _isVictory = true;
            }
            else
            {
                victoryTimer -= Time.deltaTime;
            }
        }
    }

    public void Derrota()
    {
        SceneManager.LoadScene("Derrota", LoadSceneMode.Additive);
    }
}
