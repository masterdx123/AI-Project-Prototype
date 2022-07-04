using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMaxAlgo
{
    public float bestScore;
    public float currentScore;
    public Abilities bestmove;
    public Abilities currentMove;




    
    public MiniMaxResult MiniMax(GameState gameState, int depth, bool maximizingPlayer)
    {
        Debug.Log("depth :" + depth);
      
        // starts the score of the evaluation function once it reaches the end of the tree
        if (depth == 0 || gameState.GameOver())
        {
            return new MiniMaxResult(gameState.Evaluation(), null);
        }
        bestmove = null;

        // sets the AI scores to negative and player to positive
        if (maximizingPlayer)
        {
            bestScore = Mathf.NegativeInfinity;
        }
        else
        {
            bestScore = Mathf.Infinity;
        }



        foreach (var ability in gameState.getAvailableMoves())
        {
            //sets the moves to their place in the tree and calls the recursive minimax function
            GameState newGameState = ability.UseAbility(gameState, true);
            MiniMaxResult myResult = MiniMax(newGameState, depth - 1, false);


            currentScore = myResult.score;
            currentMove = myResult.move;
            Debug.Log("Currrent Score :" + currentScore);
            Debug.Log("Currrent Move :" + currentMove);

            // if looking at the AI
            if (maximizingPlayer)
            {
                if (currentScore > bestScore)
                {
                    bestScore = currentScore;
                    bestmove = ability;
                }

            }
            // if looking at the player
            else if (currentScore < bestScore)
            {
                bestScore = currentScore;
                bestmove = ability;
            }

        }
        return new MiniMaxResult(bestScore, bestmove);
    }
}
