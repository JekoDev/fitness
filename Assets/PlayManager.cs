using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public string routineName;
    public GameObject TrainerObject;
    public GameObject PlayerObject;

    private Routine _routineData;
    private int currentnode = -1;
    private IngameUIManager uiManager;
    private bool end = false;
    private bool start = true;
     

    protected Animator animator;
    protected AnimatorOverrideController animatorOverrideController;
    protected AnimationClipOverrides clipOverrides;

    public GameObject UIPanel;
    

    // Start is called before the first frame update
    void Start()
    {
        uiManager = UIPanel.GetComponent<IngameUIManager>();
        string path = Application.persistentDataPath + "/routines/" + routineName + ".json";

        #region ###CREATION OF JSON FILE NOT FOR RUNTIME
        //Routine rr = new Routine();

        //PlayNode a = new PlayNode("routine1_1", "TrainerAnimations/" + routineName + "/exercise1_1", "TrainerVoicelines/de/de_exercise1_1", "TrainerVoicelines/en/en_exercise1_1");
        //PlayNode b = new PlayNode("routine1_2", "TrainerAnimations/" + routineName + "/exercise1_2", "TrainerVoicelines/de/de_exercise1_2", "TrainerVoicelines/en/en_exercise1_2");
        //PlayNode c = new PlayNode("routine1_3", "TrainerAnimations/" + routineName + "/exercise1_3", "TrainerVoicelines/de/de_exercise1_3", "TrainerVoicelines/en/en_exercise1_3");
        //PlayNode d = new PlayNode("routine1_4", "TrainerAnimations/" + routineName + "/exercise1_4", "TrainerVoicelines/de/de_exercise1_4", "TrainerVoicelines/en/en_exercise1_4");
        //PlayNode e = new PlayNode("routine1_5", "TrainerAnimations/" + routineName + "/exercise1_5", "TrainerVoicelines/de/de_exercise1_5", "TrainerVoicelines/en/en_exercise1_5");
        //PlayNode f = new PlayNode("routine1_6", "TrainerAnimations/" + routineName + "/exercise1_6", "TrainerVoicelines/de/de_exercise1_6", "TrainerVoicelines/en/en_exercise1_6");
        //PlayNode g = new PlayNode("routine1_7", "TrainerAnimations/" + routineName + "/exercise1_7", "TrainerVoicelines/de/de_exercise1_7", "TrainerVoicelines/en/en_exercise1_7");
        //PlayNode h = new PlayNode("routine1_8", "TrainerAnimations/" + routineName + "/exercise1_8", "TrainerVoicelines/de/de_exercise1_8", "TrainerVoicelines/en/en_exercise1_8");
        //PlayNode i = new PlayNode("routine1_9", "TrainerAnimations/" + routineName + "/exercise1_9", "TrainerVoicelines/de/de_exercise1_9", "TrainerVoicelines/en/en_exercise1_9");
        //PlayNode j = new PlayNode("routine1_10", "TrainerAnimations/" + routineName + "/exercise1_10", "TrainerVoicelines/de/de_exercise1_10", "TrainerVoicelines/en/en_exercise1_10");
        //PlayNode k = new PlayNode("routine1_11", "TrainerAnimations/" + routineName + "/exercise1_11", "TrainerVoicelines/de/de_exercise1_11", "TrainerVoicelines/en/en_exercise1_11");

        //rr.routineName = "Exercise 1";
        //rr.routineDescription = "Yoga exercise very easy difficulty";
        //rr.routineDifficulty = 1;


        //rr.nodes.Add(a);
        //rr.nodes.Add(b);
        //rr.nodes.Add(c);
        //rr.nodes.Add(d);
        //rr.nodes.Add(e);
        //rr.nodes.Add(f);
        //rr.nodes.Add(g);
        //rr.nodes.Add(h);
        //rr.nodes.Add(i);
        //rr.nodes.Add(j);
        //rr.nodes.Add(k);

        //string json = JsonUtility.ToJson(rr);


        //if (File.Exists(path))
        //    File.Delete(path);

        //if (!Directory.Exists(Application.persistentDataPath + "/routines/"))
        //    Directory.CreateDirectory(Application.persistentDataPath + "/routines/");

        //File.WriteAllText(path, json);
        #endregion

        _routineData = JsonUtility.FromJson<Routine>(File.ReadAllText(path));

        animator = TrainerObject.GetComponent<Animator>();

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        clipOverrides = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(clipOverrides);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!end)
            {
                if (start)
                {
                    PlayerObject.SetActive(true);
                    uiManager.calibrating.SetActive(false);
                    start = false;
                }
                PlayNextNode(true);
            }
            else
                SceneManager.LoadScene("Demo");

        }           


        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayFeedback(UnityEngine.Random.Range(0, 5));
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayFeedback(UnityEngine.Random.Range(6, 8));
        }
    }

    private void PlayFeedback(int v)
    {
        var audiosourceTrainer = TrainerObject.GetComponent<AudioSource>();
        var audiosourceUI = GetComponent<AudioSource>();
        AudioClip currentAudioClipTrainer = null;
        AudioClip currentAudioClipUI = null;

        if (v < 6)
            uiManager.AddPoints((int)_routineData.nodes[currentnode].nodePoints);
        else
            uiManager.AddPoints((int) -5);


        switch (v)
        {
            case 0:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_confirm_1");
                currentAudioClipUI = (AudioClip)Resources.Load("UIAudio/check_hit");
                break;
            case 1:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_confirm_2");
                currentAudioClipUI = (AudioClip)Resources.Load("UIAudio/check_hit");
                break;
            case 2:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_confirm_3");
                currentAudioClipUI = (AudioClip)Resources.Load("UIAudio/check_hit");
                break;
            case 3:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_confirm_4");
                currentAudioClipUI = (AudioClip)Resources.Load("UIAudio/check_hit");
                break;
            case 4:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_confirm_5");
                currentAudioClipUI = (AudioClip)Resources.Load("UIAudio/check_hit");
                break;
            case 5:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_confirm_6");
                currentAudioClipUI = (AudioClip)Resources.Load("UIAudio/check_hit");
                break;
            case 6:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_mistake_1");
                break;
            case 7:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_mistake_2");
                break;
            case 8:
                currentAudioClipTrainer = (AudioClip)Resources.Load("TrainerVoicelines/en/en_mistake_3");
                break;
            default:
                break;
        }

        if (currentAudioClipTrainer != null)
            audiosourceTrainer.PlayOneShot(currentAudioClipTrainer);
        if (currentAudioClipUI != null)
            audiosourceUI.PlayOneShot(currentAudioClipUI);
            
    }

    void PlayNextNode(bool trigger)
    {
        currentnode++;

        if (currentnode >= _routineData.nodes.Count)
        {
            FinishRoutine();
            end = true;
            return;
        }

        ChangeAnimation(trigger);
        ChangeAudio();
    }

    private void FinishRoutine()
    {
        var audiosource = TrainerObject.GetComponent<AudioSource>();
        var currentAudioClip = (AudioClip)Resources.Load(_routineData.exerciseEnd.resAudioNodeEn);
        audiosource.PlayOneShot(currentAudioClip);

        uiManager.ShowEndscreen();
    }

    void ChangeAnimation(bool trigger)
    {
        AnimationClip currentAnimation = (AnimationClip)Resources.Load(_routineData.nodes[currentnode].resAnimationNode);
        AnimationClip currentAnimation_idle = (AnimationClip)Resources.Load(_routineData.nodes[currentnode].resAnimationNode + "_idle");

        if (currentAnimation != null)
        {
            clipOverrides["activity"] = currentAnimation;
            clipOverrides["hold"] = currentAnimation_idle;

            animatorOverrideController.ApplyOverrides(clipOverrides);
        }
        else
            trigger = false;

        

        if(trigger)
            animator.SetTrigger("NextPose");
    }

    void ChangeAudio()
    {
        var audiosource = TrainerObject.GetComponent<AudioSource>();
        var currentAudioClip = (AudioClip)Resources.Load(_routineData.nodes[currentnode].resAudioNodeEn);
        audiosource.PlayOneShot(currentAudioClip);
    }
}

public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
{
    public AnimationClipOverrides(int capacity) : base(capacity) { }

    public AnimationClip this[string name]
    {
        get { return this.Find(x => x.Key.name.Equals(name)).Value; }
        set
        {
            int index = this.FindIndex(x => x.Key.name.Equals(name));
            if (index != -1)
                this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
        }
    }
}
