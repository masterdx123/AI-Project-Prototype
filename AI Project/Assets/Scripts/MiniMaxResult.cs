using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMaxResult
{
    public float score;
    public Abilities move;
    public MiniMaxResult(float s, Abilities m)
    {
        score = s;
        move = m;
    }
    
}
