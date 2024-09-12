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
    PersonagemStatus _status;

    [Header("StatusText")]
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI SpAtkText;
    public TextMeshProUGUI SpDefText;

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
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Jogador clicado: " + hit.transform.name);
                    Player1Status();
                    _statusUI.SetActive(true);
                }
                else
                {
                    _statusUI.SetActive(false);
                }
            }
        }
    }

    void Player1Status()
    {
        HpText.text = _status._life.ToString();
        AtkText.text = _status._damage.ToString();
        DefText.text = _status._defense.ToString();
        SpAtkText.text = _status._magicDamage.ToString();
        SpDefText.text = _status._magicDefense.ToString();
    }
}
