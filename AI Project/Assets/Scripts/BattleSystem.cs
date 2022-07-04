using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Battle states of the match
public enum BattleState { Start, PlayerTurn, AITurn, Processing, Win, Lose }

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    static public GameState gameState;

    public AIKnowledge aiKnowledge;
    public Player playerScript;

    static public TextMeshProUGUI text;
    static public Slider playerHpSlider;
    static public Slider aiHpSlider;
    static public GameObject aiGameObject;

    public bool playerTurn = false;
    public bool aiTurn = false;

    public BattleState state;

    // start match
    void Start()
    {

        text = GameObject.Find("ActionText").GetComponent<TextMeshProUGUI>();
        playerHpSlider = GameObject.Find("PlayerHPPanel").GetComponent<Slider>();
        aiHpSlider = GameObject.Find("AIHPPanel").GetComponent<Slider>();
        gameState = GetComponent<GameState>();

        SetHpHUD();

        state = BattleState.Start;
        StartCoroutine(SetBattle());
    }

    IEnumerator SetBattle()
    {
        text.text = "A bandit appeard";

        yield return new WaitForSeconds(1f);

        System.Random random = new System.Random();

        int num = random.Next(1, 3);

        text.text = "" + num;

        yield return new WaitForSeconds(1f);

        if (num == 1)
        {
            state = BattleState.PlayerTurn;
            PlayerTurn();
        }
        if (num == 2)
        {
            state = BattleState.AITurn;
            aiKnowledge.StartAITurn();
        }


    }

    public void PlayerTurn()
    {
        state = BattleState.PlayerTurn;
        playerTurn = true;
        BattleSystem.text.text = "Choose an action!";
    }



    public void Processing()
    {
        state = BattleState.Processing;
       
        aiKnowledge.lightAttackCheck = false;
        aiKnowledge.heavyAttackCheck = false;
        aiKnowledge.defenceCheck = false;
        aiKnowledge.healCheck = false;
    }

    // Sets Hp bars
    public void SetHpHUD()
    {
        playerHpSlider.maxValue = gameState.playerMaxHp;
        playerHpSlider.value = gameState.playerCurrentHp;

        aiHpSlider.maxValue = gameState.aiMaxHp;
        aiHpSlider.value = gameState.aiCurrentHp;
    }

    // Set player bar to current hp
    public void SetPlayerHP()
    {
        playerHpSlider.value = gameState.playerCurrentHp;
    }

    // Set AI bar to current hp
    public void SetAiHP()
    {
        aiHpSlider.value = gameState.aiCurrentHp;
    }
}