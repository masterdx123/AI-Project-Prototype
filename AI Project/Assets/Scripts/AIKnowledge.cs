using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIKnowledge : MonoBehaviour
{
    public bool lightAttackCheck = false;
    public bool heavyAttackCheck = false;
    public bool defenceCheck = false;
    public bool healCheck = false;

    public BattleSystem battleScript;
    public MiniMaxAlgo miniMax = new MiniMaxAlgo();

    public void StartAITurn()
    {
        StartCoroutine(AITurn());
    }

    public IEnumerator AITurn()
    {
        //Starts the minimax function
        MiniMaxResult myResult = miniMax.MiniMax(BattleSystem.gameState, 3, true);

        yield return new WaitForSeconds(2f);
        //states that it is the AI turn
        battleScript.state = BattleState.AITurn;
        battleScript.aiTurn = true;

        //shows the current best move 
        Debug.Log(myResult.move);

        // uses the ability of the best move
        BattleSystem.gameState = myResult.move.UseAbility(BattleSystem.gameState, false);
        battleScript.SetPlayerHP();

        BattleSystem.text.text = "" + miniMax.bestmove;

    
        battleScript.aiTurn = false;
        battleScript.Processing();

        yield return new WaitForSeconds(1f);
        battleScript.PlayerTurn();

    }

}