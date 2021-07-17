using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayNode
{
    public string caption;
    public string resAnimationNode;
    public string resAudioNodeDe;
    public string resAudioNodeEn;

    public float nodePoints;

    public PlayNode(string animationResourcePath, string audioResourcePath_de, string audioResourcePath_en)
    {
        caption = "none";
        nodePoints = 10.0f;
        resAnimationNode = animationResourcePath;
        resAudioNodeDe = audioResourcePath_de;
        resAudioNodeEn = audioResourcePath_en;
    }

    public PlayNode(string c, string animationResourcePath, string audioResourcePath_de, string audioResourcePath_en)
    {
        caption = c;
        nodePoints = 10.0f;

        resAnimationNode = animationResourcePath;
        resAudioNodeDe = audioResourcePath_de;
        resAudioNodeEn = audioResourcePath_en;
    }

    public PlayNode(string c, string animationResourcePath, string audioResourcePath_de, string audioResourcePath_en, float points)
    {
        caption = c;
        nodePoints = points;
        resAnimationNode = animationResourcePath;
        resAudioNodeDe = audioResourcePath_de;
        resAudioNodeEn = audioResourcePath_en;
    }
}
