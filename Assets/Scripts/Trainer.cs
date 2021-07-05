using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trainer : MonoBehaviour
{
    private Animation TrainerAnim;
    public TMP_Text Counter;
    private float Timer;
    private int State = 0;
    public AnimationClip TrainerExercise;
    public GameObject WaitAMinute;

    // Start is called before the first frame update
    void Start()
    {
        TrainerAnim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //Wait for Barracuda Init
        if (WaitAMinute.active == true)
        {
            Restart();
            return;
        }

        //To Start/Stop just enable/disable Counter
            if (Counter.enabled == true)
        {
            switch (State)
            {
                case 0:    //Counter to Trainer Anim
                    if(Time.time > Timer + 1)
                    {
                        Timer = Time.time;
                        if (Counter.text == "1") Counter.text = "0";
                        if (Counter.text == "2") Counter.text = "1";
                        if (Counter.text == "3") Counter.text = "2";
                        if (Counter.text == "0")
                        {
                            Counter.text = "";
                            TrainerAnim.AddClip(TrainerExercise, "idle");
                            TrainerAnim.clip = TrainerExercise;
                            TrainerAnim.Play("idle");
                            State = 1;
                        }
                    }
                    break;

                case 1:   //Trainer Anim
                    if (TrainerAnim.isPlaying == false)
                    {
                        Counter.text = "3";
                        State = 2;
                        Timer = Time.time;
                    }
                    break;

                case 2:  //Counter for Player
                    if (Time.time > Timer + 1)
                    {
                        Timer = Time.time;
                        if (Counter.text == "1") Counter.text = "0";
                        if (Counter.text == "2") Counter.text = "1";
                        if (Counter.text == "3") Counter.text = "2";
                        if (Counter.text == "0")
                        {
                            Counter.text = "";
                            State = 3;
                        }
                    }
                    break;

                case 3: //Player Stuff and waiting for Input
                    if (Input.GetKey(KeyCode.U))
                    {
                        Counter.text = "X";
                        State = 4;
                    }
                    if (Input.GetKey(KeyCode.I))
                    {
                        Counter.text = "O";
                        State = 4;
                    }
                    break;

                case 4: //Idle for Restart
                    if (Input.GetKey(KeyCode.O))
                    {
                        Restart();
                    }
                    break;
               
            }

        }else{
            Restart();
        }
    }

    void Restart()
    {
        Timer = Time.time;
        Counter.text = "3";
        State = 0;
    }
}
