using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    #region Properties
    private string _username;

    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }

    private int _playerlevel;

    public int Level
    {
        get { return _playerlevel; }
        set { _playerlevel = value; }
    }

    private int _language;

    public int Langauge
    {
        get { return _language; }
        set { _language = value; }
    }

    private float _musicVolume;

    private int[] _exercisepoints;

    public int[] Points
    {
        get { return _exercisepoints; }
        set { _exercisepoints = value; }
    }


    public float MusicVolume
    {
        get { return _musicVolume; }
        set { _musicVolume = value; }
    }

    private float _sfxVolume;

    public float SFXVolume
    {
        get { return _sfxVolume; }
        set { _sfxVolume = value; }
    }

    #endregion

    public PlayerInfo(PlayerInfo p)
    {
        _username = p.Username;
        _musicVolume = p.MusicVolume;
        _sfxVolume = p.SFXVolume;
        _language = p.Langauge;
        _playerlevel = p.Level;
        _exercisepoints = new int[3];
        _exercisepoints[0] = p.Points[0];
        _exercisepoints[1] = p.Points[1];
        _exercisepoints[2] = p.Points[2];
    }

    public PlayerInfo()
    {
        _username = "unidentified";
        _musicVolume = 1.0f;
        _sfxVolume = 1.0f;
        _language = 0;
        _playerlevel = 1;
        _exercisepoints[0] = 0;
        _exercisepoints[1] = 0;
        _exercisepoints[2] = 0;
    }

    public PlayerInfo(string name)
    {
        _username = name;
        _musicVolume = 1.0f;
        _sfxVolume = 1.0f;
        _language = 0;
        _playerlevel = 1;
        _exercisepoints = new int[3];
        _exercisepoints[0] = 0;
        _exercisepoints[1] = 0;
        _exercisepoints[2] = 0;
    }
}

public enum Language
{
    deDE = 0,
    enEN
}
