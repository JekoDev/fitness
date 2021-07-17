using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Routine
{
    public string routineName;
    public string routineDescription;
    public int routineDifficulty;

    public PlayNode exerciseStart;

    public List<PlayNode> nodes;

    public PlayNode exerciseEnd;

    public Routine()
    {
        nodes = new List<PlayNode>();
        routineDifficulty = 1;
        exerciseStart = new PlayNode("exercise-start", "", "TrainerVoicelines/de/de_exercise-start_1", "TrainerVoicelines/en/en_exercise-start_1", 0.0f);
        exerciseEnd = new PlayNode("exercise-end", "", "TrainerVoicelines/de/de_exercise-end_1", "TrainerVoicelines/en/en_exercise-end_1", 0.0f);
    }
}
