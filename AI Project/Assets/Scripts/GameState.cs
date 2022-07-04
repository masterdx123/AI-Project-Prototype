using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState: MonoBehaviour 
{

    BattleSystem system;

    // player and AI stats

    public int playerMaxHp = 100;
    public int playerCurrentHp = 100;
    public int playerDmg = 15;

    public int aiMaxHp = 100;
    public int aiCurrentHp = 100;
    public int aiDmg = 15;



    private void Start()
    {
        system = GetComponent<BattleSystem>();
        system.state = BattleState.Start;
    }

    public bool GameOver()
    {
        if (aiCurrentHp == 0)
        {
            //player wins the match
            system.state = BattleState.Win;
            Time.timeScale = 0;
            return true;
        }
        if (playerCurrentHp == 0)
        {
            //player loses the match
            system.state = BattleState.Lose;
            Time.timeScale = 0;
            return true;
        }
        return false;
    }

    public float Evaluation()
    {
        // return value used in the selection of the move
        return playerCurrentHp - aiCurrentHp;
    }

    // add abilities to the list of abilities
    public List<Abilities> getAvailableMoves()
    {
        List<Abilities> returnVal = new List<Abilities>();
        returnVal.Add(new Abilities.LightAttack());
        returnVal.Add(new Abilities.HeavyAttack());
        returnVal.Add(new Abilities.Heal());

        return returnVal;
    }


}
