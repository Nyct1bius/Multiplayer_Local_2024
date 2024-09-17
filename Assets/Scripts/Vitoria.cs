using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{

    public BattleManager BattleManager;
    public GameManager GameManager;

    [Header("StatusTextPlayer1")]
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI SpAtkText;
    public TextMeshProUGUI SpDefText;

    [Header("StatusPlusTextPlayer1")]
    public TextMeshProUGUI PlusHpText;
    public TextMeshProUGUI PlusAtkText;
    public TextMeshProUGUI PlusDefText;
    public TextMeshProUGUI PlusSpAtkText;
    public TextMeshProUGUI PlusSpDefText;

    [Header("StatusTextPlayer2")]
    public TextMeshProUGUI HpText2;
    public TextMeshProUGUI AtkText2;
    public TextMeshProUGUI DefText2;
    public TextMeshProUGUI SpAtkText2;
    public TextMeshProUGUI SpDefText2;

    [Header("StatusPlusTextPlayer2")]
    public TextMeshProUGUI PlusHpText2;
    public TextMeshProUGUI PlusAtkText2;
    public TextMeshProUGUI PlusDefText2;
    public TextMeshProUGUI PlusSpAtkText2;
    public TextMeshProUGUI PlusSpDefText2;

    // Start is called before the first frame update
    void Start()
    {
        BattleManager = FindAnyObjectByType<BattleManager>();
        GameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
