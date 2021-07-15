using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerManager
{
    #region Properties
    private string storagepath = Application.persistentDataPath + "/player.sav";

    private PlayerInfo _player;

    public PlayerInfo Player
    {
        get { return _player; }
        set { _player = value; }
    }

    #endregion

    #region constructors

    public PlayerManager()
    {

    }

    #endregion

    #region Functions

    #region SaveLoad PlayerData

    public void SavePlayer()
    {
        if (_player != null)
        {
            BinaryFormatter storage = new BinaryFormatter();
            using (FileStream s = new FileStream(storagepath, FileMode.Create))
            {
                storage.Serialize(s, _player);
                s.Close();
            } 
        }
    }
    
    public void CreatePlayer(string username)
    {
        _player = new PlayerInfo(username);
    }

    public void LoadPlayer()
    {
        if (PlayerExists())
        {
            BinaryFormatter storage = new BinaryFormatter();
            using (FileStream s = new FileStream(storagepath, FileMode.Open))
            {
                _player = (PlayerInfo)storage.Deserialize(s);
                s.Close();
            }
        }
    }



    public bool PlayerExists()
    {
        return File.Exists(Application.persistentDataPath + "/player.sav");
    }

    #endregion

    #region Settings

    public void SetMusicVolume(float value)
    {
        _player.MusicVolume = value;
        Debug.Log(_player.MusicVolume);

    }

    public void SetSFXVolume(float value)
    {
        _player.SFXVolume = value;
        Debug.Log(_player.SFXVolume);
    }

    public void SetLanguage(Language l)
    {
        _player.Langauge = (int)l;

        Debug.Log(_player.Langauge.ToString());

    }

    #endregion

    #endregion

    
}
