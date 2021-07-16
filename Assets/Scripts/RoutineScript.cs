using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutineScript : MonoBehaviour
{



    //Exercise bools , activate the corresponding exercise to trigger the sequence
    //exercise 1 is Tree Pose, exercise 2 is Squats, exercise 3 is Abdominal Leg lifts
    public bool doingTreePose;
    public bool doingSquats;
    public bool doingLegLifts;
    public bool inDE;
    public bool inEN;

    //voicelines
    //de
    [Header("Voice Clips")]
    public AudioClip[] de_break;
    public AudioClip[] de_confirm;
    public AudioClip[] de_danger;
    public AudioClip[] de_exercise1;
    public AudioClip[] de_exercise2;
    public AudioClip[] de_exerciseStart;
    public AudioClip[] de_exerciseEnd;
    public AudioClip[] de_idle;
    public AudioClip[] de_mistake;
    //public AudioClip[] de_exercise3; not done yet?

    //en
    public AudioClip[] en_break;
    public AudioClip[] en_confirm;
    public AudioClip[] en_danger;
    public AudioClip[] en_exercise1;
    public AudioClip[] en_exercise2;
    public AudioClip[] en_exerciseStart;
    public AudioClip[] en_exerciseEnd;
    public AudioClip[] en_idle;
    public AudioClip[] en_mistake;
    //public AudioClip[] en_exercise3; not done yet?

    public AudioSource audiosource;

    private int randomFromArray;

    //animations
    [Header("Animation Clips")]
    public AnimationClip[] exercise1Anim;
    public AnimationClip[] exercise2Anim;
    public AnimationClip[] exercise3Anim;

    //These bools prevent clips from repeating
    //private bool audioClipStartPlaying;
    public bool[] audioClipPlaying;
    /*
    private bool audioClip1Playing;
    private bool audioClip2Playing;
    private bool audioClip3Playing;
    private bool audioClip4Playing;
    private bool audioClip5Playing;
    private bool audioClip6Playing;
    private bool audioClip7Playing;
    private bool audioClip8Playing;
    private bool audioClip9Playing;
    private bool audioClip10Playing;
    private bool audioClip11Playing;
    private bool audioClip12Playing;
    private bool audioClip13Playing;
    private bool audioClip14Playing;*/
    private bool audioClipEndPlaying;

    public bool[] audioClipPlayed = new bool[14];
    /*
    private bool audioClipStartPlayed;
    private bool audioClip1Played;
    private bool audioClip2Played;
    private bool audioClip3Played;
    private bool audioClip4Played;
    private bool audioClip5Played;
    private bool audioClip6Played;
    private bool audioClip7Played;
    private bool audioClip8Played;
    private bool audioClip9Played;
    private bool audioClip10Played;
    private bool audioClip11Played;
    private bool audioClip12Played;
    private bool audioClip13Played;
    private bool audioClip14Played;*/
    private bool audioClipEndPlayed;

    public int currentAudioIndex;

    private float waitCooldownStart;
    private float waitCooldown1;
    private float waitCooldown2;
    private float waitCooldown3;
    private float waitCooldown4;
    private float waitCooldown5;
    private float waitCooldown6;
    private float waitCooldown7;
    private float waitCooldown8;
    private float waitCooldown9;
    private float waitCooldown10;
    private float waitCooldown11;
    private float waitCooldown12;
    private float waitCooldown13;
    private float waitCooldown14;
    private float waitCooldownEnd;

    private float waitTimer;

    //feedback
    private bool queuedConfirm;
    private bool queuedMistake;

    private bool isAudioRunning;

    // Start is called before the first frame update
    void Start()
    {

        audioClipPlayed = new bool[14];
        audioClipPlaying = new bool[14];

    }

    // Update is called once per frame
    void Update()
    {
        //Moony's code below this line (except for the Restart function)

        if (doingTreePose == true && inDE)
            Routine1DE();
        else if (doingSquats == true && inDE)
            Routine2DE();
        else if (doingLegLifts == true && inDE)
            Routine3DE();
        else if (doingTreePose == true && inEN)
            Routine1EN();
        else if (doingSquats == true && inEN)
            Routine2EN();
        else if (doingLegLifts == true && inEN)
            Routine3EN();
        else
            print("ERROR: No exercise or language chosen??");
    }
    void Routine1DE()
    {
        waitTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //confirm
            queuedConfirm = true;
            if (queuedMistake == true)
            {
                queuedMistake = false;
            }
            if (audioClipPlaying[currentAudioIndex] == false)
            {
                Feedback();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //mistake
            queuedMistake = true;
            if (queuedConfirm == true)
            {
                queuedConfirm = false;
            }
            if (audioClipPlaying[currentAudioIndex] == false)
            {
                Feedback();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //danger... is difficult to implement.
            //it's meant to immediately stop the current activity to play the audio clip,
            //then restart from the top of that audioclip
        }


        //Edit under here how much time an audioclip should wait since the clip before finished playing (so that timing isn't awkward)
        waitCooldownStart = 0;
        waitCooldown1 = 0;
        waitCooldown2 = 0;
        waitCooldown3 = 0;
        waitCooldown4 = 0;
        waitCooldown5 = 0;
        waitCooldown6 = 0;
        waitCooldown7 = 0;
        waitCooldown8 = 0;
        waitCooldown9 = 0;
        waitCooldown10 = 0;
        waitCooldown11 = 0;
        waitCooldown12 = 0;
        waitCooldown13 = 0;
        waitCooldown14 = 0;
        waitCooldownEnd = 0;

        //need 11 of these + start and end
        if (audioClipPlaying[0] == false && audioClipPlayed[0] == false && waitTimer >= waitCooldownStart)
        {
            randomFromArray = Random.Range(0, de_exerciseStart.Length);
            audiosource.PlayOneShot(de_exerciseStart[randomFromArray]);
            currentAudioIndex = 0;
            isAudioRunning = true;
        }


        if (audioClipPlaying[1] == false && audioClipPlayed[1] == false && waitTimer >= waitCooldown1 && audioClipPlayed[0] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[1]);
            isAudioRunning = true; ;
        }

        if (audioClipPlaying[2] == false && audioClipPlayed[2] == false && waitTimer >= waitCooldown2 && audioClipPlayed[1] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[2]);
            isAudioRunning = true;
        }

        if (audioClipPlaying[3] == false && audioClipPlayed[3] == false && waitTimer >= waitCooldown3 && audioClipPlayed[2] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[3]);
            isAudioRunning = true;
        }

        if (audioClipPlaying[4] == false && audioClipPlayed[4] == false && waitTimer >= waitCooldown4 && audioClipPlayed[3] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[4]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[5] == false && audioClipPlayed[5] == false && waitTimer >= waitCooldown5 && audioClipPlayed[4] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[5]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[6] == false && audioClipPlayed[6] == false && waitTimer >= waitCooldown6 && audioClipPlayed[5] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[6]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[7] == false && audioClipPlayed[7] == false && waitTimer >= waitCooldown7 && audioClipPlayed[6] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[7]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[8] == false && audioClipPlayed[8] == false && waitTimer >= waitCooldown8 && audioClipPlayed[7] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[8]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[9] == false && audioClipPlayed[9] == false && waitTimer >= waitCooldown9 && audioClipPlayed[8] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[9]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[10] == false && audioClipPlayed[10] == false && waitTimer >= waitCooldown10 && audioClipPlayed[9] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise1[10]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[11] == false && audioClipPlayed[11] == false && waitTimer >= waitCooldown11 && audioClipPlayed[10] == true && Input.GetKeyDown(KeyCode.Space))
        {
            randomFromArray = Random.Range(0, de_exerciseEnd.Length);
            audiosource.PlayOneShot(de_exerciseEnd[randomFromArray]);
            isAudioRunning = true;
        }


        if (isAudioRunning == true)
        {
            PlayingAudioClip();
        }

    }
    void Routine2DE()
    {
        waitTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //confirm
            queuedConfirm = true;
            if (queuedMistake == true)
            {
                queuedMistake = false;
            }
            if (audioClipPlaying[currentAudioIndex] == false)
            {
                Feedback();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //mistake
            queuedMistake = true;
            if (queuedConfirm == true)
            {
                queuedConfirm = false;
            }
            if (audioClipPlaying[currentAudioIndex] == false)
            {
                Feedback();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //danger... is difficult to implement.
            //it's meant to immediately stop the current activity to play the audio clip,
            //then restart from the top of that audioclip
        }


        //Edit under here how much time an audioclip should wait since the clip before finished playing (so that timing isn't awkward)
        waitCooldownStart = 0;
        waitCooldown1 = 0;
        waitCooldown2 = 0;
        waitCooldown3 = 0;
        waitCooldown4 = 0;
        waitCooldown5 = 0;
        waitCooldown6 = 0;
        waitCooldown7 = 0;
        waitCooldown8 = 0;
        waitCooldown9 = 0;
        waitCooldown10 = 0;
        waitCooldown11 = 0;
        waitCooldown12 = 0;
        waitCooldown13 = 0;
        waitCooldown14 = 0;
        waitCooldownEnd = 0;

        //need 11 of these + start and end
        if (audioClipPlaying[0] == false && audioClipPlayed[0] == false && waitTimer >= waitCooldownStart)
        {
            randomFromArray = Random.Range(0, de_exerciseStart.Length);
            audiosource.PlayOneShot(de_exerciseStart[randomFromArray]);
            currentAudioIndex = 0;
            isAudioRunning = true;
        }


        if (audioClipPlaying[1] == false && audioClipPlayed[1] == false && waitTimer >= waitCooldown1 && audioClipPlayed[0] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise2[1]);
            isAudioRunning = true; ;
        }

        if (audioClipPlaying[2] == false && audioClipPlayed[2] == false && waitTimer >= waitCooldown2 && audioClipPlayed[1] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise2[2]);
            isAudioRunning = true;
        }

        if (audioClipPlaying[3] == false && audioClipPlayed[3] == false && waitTimer >= waitCooldown3 && audioClipPlayed[2] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise2[3]);
            isAudioRunning = true;
        }

        if (audioClipPlaying[4] == false && audioClipPlayed[4] == false && waitTimer >= waitCooldown4 && audioClipPlayed[3] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(de_exercise2[4]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[5] == false && audioClipPlayed[5] == false && waitTimer >= waitCooldown5 && audioClipPlayed[4] == true && Input.GetKeyDown(KeyCode.Space))
        {
            randomFromArray = Random.Range(0, de_exerciseEnd.Length);
            audiosource.PlayOneShot(de_exerciseEnd[randomFromArray]);
            isAudioRunning = true;
        }


        if (isAudioRunning == true)
        {
            PlayingAudioClip();
        }

    }
    void Routine3DE()
    {
        randomFromArray = Random.Range(0, de_exerciseStart.Length);
        audiosource.PlayOneShot(de_exerciseStart[randomFromArray]);
    }
    void Routine1EN()
    {
        waitTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //confirm
            queuedConfirm = true;
            if (queuedMistake == true)
            {
                queuedMistake = false;
            }
            if (audioClipPlaying[currentAudioIndex] == false)
            {
                Feedback();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //mistake
            queuedMistake = true;
            if (queuedConfirm == true)
            {
                queuedConfirm = false;
            }
            if (audioClipPlaying[currentAudioIndex] == false)
            {
                Feedback();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //danger... is difficult to implement.
            //it's meant to immediately stop the current activity to play the audio clip,
            //then restart from the top of that audioclip
        }


        //Edit under here how much time an audioclip should wait since the clip before finished playing (so that timing isn't awkward)
        waitCooldownStart = 0;
        waitCooldown1 = 0;
        waitCooldown2 = 0;
        waitCooldown3 = 0;
        waitCooldown4 = 0;
        waitCooldown5 = 0;
        waitCooldown6 = 0;
        waitCooldown7 = 0;
        waitCooldown8 = 0;
        waitCooldown9 = 0;
        waitCooldown10 = 0;
        waitCooldown11 = 0;
        waitCooldown12 = 0;
        waitCooldown13 = 0;
        waitCooldown14 = 0;
        waitCooldownEnd = 0;

        //need 11 of these + start and end
        if (audioClipPlaying[0] == false && audioClipPlayed[0] == false && waitTimer >= waitCooldownStart)
        {
            randomFromArray = Random.Range(0, en_exerciseStart.Length);
            audiosource.PlayOneShot(en_exerciseStart[randomFromArray]);
            currentAudioIndex = 0;
            isAudioRunning = true;
        }


        if (audioClipPlaying[1] == false && audioClipPlayed[1] == false && waitTimer >= waitCooldown1 && audioClipPlayed[0] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[1]);
            isAudioRunning = true; ;
        }

        if (audioClipPlaying[2] == false && audioClipPlayed[2] == false && waitTimer >= waitCooldown2 && audioClipPlayed[1] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[2]);
            isAudioRunning = true;
        }

        if (audioClipPlaying[3] == false && audioClipPlayed[3] == false && waitTimer >= waitCooldown3 && audioClipPlayed[2] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[3]);
            isAudioRunning = true;
        }

        if (audioClipPlaying[4] == false && audioClipPlayed[4] == false && waitTimer >= waitCooldown4 && audioClipPlayed[3] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[4]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[5] == false && audioClipPlayed[5] == false && waitTimer >= waitCooldown5 && audioClipPlayed[4] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[5]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[6] == false && audioClipPlayed[6] == false && waitTimer >= waitCooldown6 && audioClipPlayed[5] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[6]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[7] == false && audioClipPlayed[7] == false && waitTimer >= waitCooldown7 && audioClipPlayed[6] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[7]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[8] == false && audioClipPlayed[8] == false && waitTimer >= waitCooldown8 && audioClipPlayed[7] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[8]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[9] == false && audioClipPlayed[9] == false && waitTimer >= waitCooldown9 && audioClipPlayed[8] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[9]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[10] == false && audioClipPlayed[10] == false && waitTimer >= waitCooldown10 && audioClipPlayed[9] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise1[10]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[11] == false && audioClipPlayed[11] == false && waitTimer >= waitCooldown11 && audioClipPlayed[10] == true && Input.GetKeyDown(KeyCode.Space))
        {
            randomFromArray = Random.Range(0, en_exerciseEnd.Length);
            audiosource.PlayOneShot(en_exerciseEnd[randomFromArray]);
            isAudioRunning = true;
        }


        if (isAudioRunning == true)
        {
            PlayingAudioClip();
        }
    }
    void Routine2EN()
    {
        waitTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //confirm
            queuedConfirm = true;
            if (queuedMistake == true)
            {
                queuedMistake = false;
            }
            if (audioClipPlaying[currentAudioIndex] == false)
            {
                Feedback();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //mistake
            queuedMistake = true;
            if (queuedConfirm == true)
            {
                queuedConfirm = false;
            }
            if (audioClipPlaying[currentAudioIndex] == false)
            {
                Feedback();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //danger... is difficult to implement.
            //it's meant to immediately stop the current activity to play the audio clip,
            //then restart from the top of that audioclip
        }


        //Edit under here how much time an audioclip should wait since the clip before finished playing (so that timing isn't awkward)
        waitCooldownStart = 0;
        waitCooldown1 = 0;
        waitCooldown2 = 0;
        waitCooldown3 = 0;
        waitCooldown4 = 0;
        waitCooldown5 = 0;
        waitCooldown6 = 0;
        waitCooldown7 = 0;
        waitCooldown8 = 0;
        waitCooldown9 = 0;
        waitCooldown10 = 0;
        waitCooldown11 = 0;
        waitCooldown12 = 0;
        waitCooldown13 = 0;
        waitCooldown14 = 0;
        waitCooldownEnd = 0;

        //need 11 of these + start and end
        if (audioClipPlaying[0] == false && audioClipPlayed[0] == false && waitTimer >= waitCooldownStart)
        {
            randomFromArray = Random.Range(0, en_exerciseStart.Length);
            audiosource.PlayOneShot(en_exerciseStart[randomFromArray]);
            currentAudioIndex = 0;
            isAudioRunning = true;
        }


        if (audioClipPlaying[1] == false && audioClipPlayed[1] == false && waitTimer >= waitCooldown1 && audioClipPlayed[0] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise2[1]);
            isAudioRunning = true; ;
        }

        if (audioClipPlaying[2] == false && audioClipPlayed[2] == false && waitTimer >= waitCooldown2 && audioClipPlayed[1] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise2[2]);
            isAudioRunning = true;
        }

        if (audioClipPlaying[3] == false && audioClipPlayed[3] == false && waitTimer >= waitCooldown3 && audioClipPlayed[2] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise2[3]);
            isAudioRunning = true;
        }

        if (audioClipPlaying[4] == false && audioClipPlayed[4] == false && waitTimer >= waitCooldown4 && audioClipPlayed[3] == true && Input.GetKeyDown(KeyCode.Space))
        {
            audiosource.PlayOneShot(en_exercise2[4]);
            isAudioRunning = true;
        }
        if (audioClipPlaying[5] == false && audioClipPlayed[5] == false && waitTimer >= waitCooldown5 && audioClipPlayed[4] == true && Input.GetKeyDown(KeyCode.Space))
        {
            randomFromArray = Random.Range(0, de_exerciseEnd.Length);
            audiosource.PlayOneShot(en_exerciseEnd[randomFromArray]);
            isAudioRunning = true;
        }


        if (isAudioRunning == true)
        {
            PlayingAudioClip();
        }
    }
    void Routine3EN()
    {
        randomFromArray = Random.Range(0, en_exerciseStart.Length);
        audiosource.PlayOneShot(de_exerciseStart[randomFromArray]);
    }

    void PlayingAudioClip()
    {

        if (audiosource.isPlaying == true)
        {
            audioClipPlaying[currentAudioIndex] = true;
            print("loop");
        }
        else
        {
            print("loop2");
            audioClipPlaying[currentAudioIndex] = false;
            audioClipPlayed[currentAudioIndex] = true;
            waitTimer = 0;
            if (queuedConfirm == true || queuedMistake == true)
            {
                Feedback();
            }
            currentAudioIndex++;
            isAudioRunning = false;
        }


    }

    void Feedback()
    {
        if (queuedConfirm == true)
        {
            if (inDE == true)
            {
                randomFromArray = Random.Range(0, de_confirm.Length);
                audiosource.clip = de_confirm[randomFromArray];
                audiosource.PlayDelayed(1f);
                waitTimer = -1.5f;
                queuedConfirm = false;
            }
            else
            {
                randomFromArray = Random.Range(0, en_confirm.Length);
                audiosource.clip = en_confirm[randomFromArray];
                audiosource.PlayDelayed(1f);
                waitTimer = -1.5f;
                queuedConfirm = false;
            }
        }
        else if (queuedMistake == true)
        {
            if (inDE == true)
            {
                randomFromArray = Random.Range(0, de_mistake.Length);
                audiosource.clip = de_mistake[randomFromArray];
                audiosource.PlayDelayed(1f);
                waitTimer = -3f;
                queuedMistake = false;
            }
            else
            {
                randomFromArray = Random.Range(0, en_mistake.Length);
                audiosource.clip = en_mistake[randomFromArray];
                audiosource.PlayDelayed(1f);
                waitTimer = -3f;
                queuedMistake = false;

            }
        }
    }
}
