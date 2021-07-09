using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{
    #region Properties
    private string _username;

    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }

    private int _points;

    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }

    private Dictionary<Challenge, ChallengeInfo> _progress;

    public Dictionary<Challenge, ChallengeInfo> Progress
    {
        get { return _progress; }
        set { _progress = value; }
    }

    #endregion

    public PlayerInfo()
    {
        _progress = new Dictionary<Challenge, ChallengeInfo>();
        _progress[Challenge.Yoga] = new ChallengeInfo(Challenge.Yoga);
        _progress[Challenge.Yoga] = new ChallengeInfo(Challenge.Boxing);
        _progress[Challenge.Yoga] = new ChallengeInfo(Challenge.Running);
    }


    public void UpdateChallengeInfo(Challenge c, int points)
    {
       _progress[c].ChallengePoints = points;
    }
}
