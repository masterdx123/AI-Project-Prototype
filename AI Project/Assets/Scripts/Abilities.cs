using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities
{


    public virtual GameState UseAbility(GameState state, bool isPlayerTurn)
    {
        return state;
    }

    
    public class LightAttack : Abilities
    {
        // AI uses Light Attack 
        public override GameState UseAbility(GameState state, bool isPlayerTurn)
        {
           

            state.aiDmg = 15;
            state.playerDmg = 15;

            if (isPlayerTurn)
            {

                state.aiCurrentHp -= state.playerDmg;
            }
            else
            {
                state.playerCurrentHp -= state.aiDmg;
            }

        
            return state;
        }
    }


    
    public class HeavyAttack : Abilities
    {
        // AI uses Heavy Attack
        public override GameState UseAbility(GameState state, bool isPlayerTurn)
        {
            state.playerDmg *= 3;
            state.aiDmg *= 3;

            if (isPlayerTurn)
            {
                state.aiCurrentHp -= state.playerDmg;
            }
            else
            {
                state.playerCurrentHp -= state.aiDmg;
            }

            return state;
        }
    }

    
    public class Heal : Abilities
    {
        // AI uses Heal 
        public override GameState UseAbility(GameState state, bool isPlayerTurn)
        {


            if (isPlayerTurn)
            {
                state.playerCurrentHp += 60;

                if (state.playerCurrentHp > state.playerMaxHp)
                {
                    state.playerCurrentHp = state.playerMaxHp;
                }
            }
            else
            {
                state.aiCurrentHp += 60;

                if (state.aiCurrentHp > state.aiMaxHp)
                {
                    state.aiCurrentHp = state.aiMaxHp;
                }
            }

            return state;
        }
    }

    
}