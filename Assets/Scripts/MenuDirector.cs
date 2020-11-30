using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuDirector : MonoBehaviour
{
    GameObject titleLogo;
    GameObject howToPlayImage;
    GameObject justStopModeImage;
    GameObject timeAttackModeImage;
    public static int miniCarUnlockQuota;
    public static int buggyUnlockQuota;
    public static int truckUnlockQuota;
    public static int sportsCarUnlockQuota;
    public static int f1CarUnlockQuota;
    Text JSMFirstRecord;
    Text JSMSecondRecord;
    Text JSMThirdRecord;
    Text TAMFirstRecord;
    Text TAMSecondRecord;
    Text TAMThirdRecord;
    Button howToPlayButton;
    AudioSource buttonClickSound;
    Animation anim;
    float time;
    bool playOnce;
    
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        playOnce = true;
        titleLogo = GameObject.Find("TitleLogo");
        howToPlayImage = GameObject.Find("HowToPlayImage");
        justStopModeImage = GameObject.Find("JustStopModeImage");
        timeAttackModeImage = GameObject.Find("TimeAttackModeImage");
        howToPlayButton = GameObject.Find("HowToPlayButton").GetComponent<Button>();
        JSMFirstRecord = GameObject.Find("JSTFirstRecord").GetComponent<Text>();
        JSMSecondRecord = GameObject.Find("JSTSecondRecord").GetComponent<Text>();
        JSMThirdRecord = GameObject.Find("JSTThirdRecord").GetComponent<Text>();
        TAMFirstRecord = GameObject.Find("TAMFirstRecord").GetComponent<Text>();
        TAMSecondRecord = GameObject.Find("TAMSecondRecord").GetComponent<Text>();
        TAMThirdRecord = GameObject.Find("TAMThirdRecord").GetComponent<Text>();
        miniCarUnlockQuota = 5;
        buggyUnlockQuota = 5;
        truckUnlockQuota = 5;
        sportsCarUnlockQuota = 5;
        f1CarUnlockQuota = 5;
        howToPlayButton.interactable = true;
        howToPlayImage.SetActive(false);
        justStopModeImage.SetActive(false);
        timeAttackModeImage.SetActive(false);
        anim = titleLogo.GetComponent<Animation>();
        buttonClickSound = GetComponent<AudioSource>();
        writeRecord();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1.0f)
        {
            if (playOnce)
            {
                anim.Play();
                playOnce = false;
            } 
        }
    }

    public void JustStopModeButton()
    {
        justStopModeImage.SetActive(true);
        howToPlayButton.interactable = false;
        buttonClickSound.Play();
    }

    public void JustStopModeStartButton()
    {
        CarController.GameMode(1);
        GameDirector.GameMode(1);
        SceneManager.LoadScene("GamePlayScene");
    }

    public void JustStopModeBackButton()
    {
        justStopModeImage.SetActive(false);
        howToPlayButton.interactable = true;
        buttonClickSound.Play();
    }

    public void TimeAttackModeButton()
    {
        timeAttackModeImage.SetActive(true);
        howToPlayButton.interactable = false;
        buttonClickSound.Play();
    }

    public void TimeAttackModeStartButton()
    {
        CarController.GameMode(2);
        GameDirector.GameMode(2);
        SceneManager.LoadScene("GamePlayScene");
    }

    public void TimeAttackModeBackButton()
    {
        timeAttackModeImage.SetActive(false);
        howToPlayButton.interactable = true;
        buttonClickSound.Play();
    }

    public void HowToPlayButton()
    {
        howToPlayImage.SetActive(true);
        buttonClickSound.Play();
    }

    public void HowToPlayBackButton()
    {
        howToPlayImage.SetActive(false);
        buttonClickSound.Play();
    }

    public void JSMResetButton()
    {
        Record record = new Record();
        record = record.LoadRecords();
        record.JSMfirst = 999;
        record.JSMsecond = 999;
        record.JSMthird = 999;
        record.SaveRecords(record);
        JSMFirstRecord.text = "no record";
        JSMSecondRecord.text = "no record";
        JSMThirdRecord.text = "no record";
    }

    public void TAMResetButton()
    {
        Record record = new Record();
        record = record.LoadRecords();
        record.TAMfirst = 0;
        record.TAMsecond = 0;
        record.TAMthird = 0;
        record.SaveRecords(record);
        TAMFirstRecord.text = "no record";
        TAMSecondRecord.text = "no record";
        TAMThirdRecord.text = "no record";
    }

    public void writeRecord()
    {
        Record records = new Record();
        records = records.LoadRecords();
        if (records.JSMfirst != 999)
        {
            JSMFirstRecord.text = "1st:" + records.JSMfirst;
        }
        else
        {
            JSMFirstRecord.text = "no record";
        }
        if (records.JSMsecond != 999)
        {
            JSMSecondRecord.text = "2nd:" + records.JSMsecond;
        }
        else
        {
            JSMSecondRecord.text = "no record";
        }
        if (records.JSMthird != 999)
        {
            JSMThirdRecord.text = "3rd:" + records.JSMthird;
        }
        else
        {
            JSMThirdRecord.text = "no record";
        }

        if (records.TAMfirst != 0)
        {
            TAMFirstRecord.text = "1st:" + records.TAMfirst;
        }
        else
        {
            TAMFirstRecord.text = "no record";
        }
        if (records.TAMsecond != 0)
        {
            TAMSecondRecord.text = "2nd:" + records.TAMsecond;
        }
        else
        {
            TAMSecondRecord.text = "no record";
        }
        if (records.TAMthird != 0)
        {
            TAMThirdRecord.text = "3rd:" + records.TAMthird;
        }
        else
        {
            TAMThirdRecord.text = "no record";
        }

    }
}
