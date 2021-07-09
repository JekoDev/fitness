using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeInfo
{
    #region Properties
    private Challenge _challengeName;

    public Challenge ChallengeName
    {
        get { return _challengeName; }
        set { _challengeName = value; }
    }

    private int _challengePoints;

    public int ChallengePoints
    {
        get { return _challengePoints; }
        set { _challengePoints = value; }
    }

    #endregion

    public ChallengeInfo()
    {
        _challengePoints = 0;
        _challengeName = Challenge.None;
    }

    public ChallengeInfo(Challenge name)
    {
        _challengePoints = 0;
        _challengeName = name;
    }
}

public enum Challenge
{
    None = 0,
    Yoga,
    Boxing,
    Running
}
