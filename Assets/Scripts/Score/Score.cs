using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Score 
{
    public string nickname;
    public float timeScore;
    public float hpScore;

    public Score(string nickname, float timeScore, float hpScore)
    {
        this.nickname = nickname;
        this.timeScore = timeScore;
        this.hpScore = hpScore;
    }
}
