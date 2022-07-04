using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public BattleSystem battleScript;
    public AIKnowledge aiKnowledge;



    public void LightAttack()
    {
        BattleSystem.gameState.playerDmg = 15;
        //player uses Light Attack
        if (battleScript.playerTurn == true)
        {
            BattleSystem.gameState.aiCurrentHp -= BattleSystem.gameState.playerDmg;

            aiKnowledge.lightAttackCheck = true;
            battleScript.SetAiHP();
            battleScript.playerTurn = false;
            aiKnowledge.StartAITurn();
        }

    }


    public void HeavyAttack()
    {
        BattleSystem.gameState.playerDmg = 15;
        //player uses heavy attack
        if (battleScript.playerTurn == true)
        {
            BattleSystem.gameState.playerDmg *= 3;
            BattleSystem.gameState.aiCurrentHp -= BattleSystem.gameState.playerDmg;


            battleScript.SetAiHP();

        }

    }

    public void Heal()
    {
        //player uses heal
        if (battleScript.playerTurn == true)
        {
            BattleSystem.gameState.playerCurrentHp += 60;

            aiKnowledge.healCheck = true;
            battleScript.SetPlayerHP();
            aiKnowledge.StartAITurn();
        }
    }

    static public void Defence()
    {

    }




}

