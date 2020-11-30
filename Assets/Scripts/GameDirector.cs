using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameDirector : MonoBehaviour
{
	GameObject car;
    GameObject mainCamera;
    static GameObject stopLine;
    GameObject distance;
    static GameObject timeLimit;
    GameObject retryButton;
    GameObject titleButton;
    GameObject pauseDisplay;
    GameObject pauseButton;
    GameObject carunlockImage;
    public Sprite pauseImage;
    public Sprite playImage;
    Animation anim;
    AudioSource apploudSound;
    AudioSource bgmAudio;
    AudioSource bgmAudio2;
    AudioSource bgmAudio3;
    AudioSource carUnlockSound;
    //public AudioClip gameBgm;
    //public AudioClip gameBgm2;
    //public AudioClip gameBgm3;
    int bgmDice;
    bool playOnce;
    bool isPauseButtonPushed;
    static bool isGameOver = false;
    float length;
    public static float limit;
    float startPos;
    static int gameMode;

    // Start is called before the first frame update
    void Start()
    {
        car = CarController.cars[CarController.selectedCarNumber];
        mainCamera = GameObject.Find("MainCamera");
        stopLine = GameObject.Find("StopLine");
        distance = GameObject.Find("Distance");
        timeLimit = GameObject.Find("TimeLimit");
        retryButton = GameObject.Find("RetryButton");
        titleButton = GameObject.Find("TitleButton");
        pauseDisplay = GameObject.Find("PauseDisplay");
        pauseButton = GameObject.Find("PauseButton");
        carunlockImage = GameObject.Find("CarUnlockImage");
        pauseDisplay.SetActive(false);
        retryButton.SetActive(false);
        titleButton.SetActive(false);
        pauseButton.SetActive(true);
        timeLimit.SetActive(false);
        carunlockImage.SetActive(false);
        isGameOver = false;
        isPauseButtonPushed = false;
        playOnce = true;
        startPos = this.car.transform.GetChild(0).position.x;
        anim = distance.GetComponent<Animation>();
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();
        apploudSound = audioSources[0];
        bgmAudio = audioSources[1];
        bgmAudio2 = audioSources[2];
        bgmAudio3 = audioSources[3];
        carUnlockSound = audioSources[4];
        bgmDice = UnityEngine.Random.Range(1, 4);
        switch (bgmDice)
        {
            case 1:
                //bgmAudio.PlayOneShot(gameBgm);
                bgmAudio.Play();
                break;
            case 2:
                //bgmAudio.PlayOneShot(gameBgm2);
                bgmAudio2.Play();
                break;
            case 3:
                //bgmAudio.PlayOneShot(gameBgm3);
                bgmAudio3.Play();
                break;
        }
        length = 0;
        limit = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == 1)
        {
            JustStopMode();
        }
        else
        {
            TimeAttackMode();
        }
    }

    public void JustStopMode()
    {
        if (length < -200)
        {
            isGameOver = true;
        }

        if (!isGameOver)
        {
            length = stopLine.transform.position.x - this.car.transform.GetChild(0).position.x;
            this.distance.GetComponent<Text>().text = "目標まで:" + length.ToString("F2") + "m";
        }
        else
        {

            if (playOnce)
            {
                CameraController.GameOverFlag();
                ObjectController.GameOverFlag(true);
                BackgroundController.GameOverFlag();
                CarController.GameOverFlag();
                retryButton.SetActive(true);
                titleButton.SetActive(true);
                pauseButton.SetActive(false);
                this.distance.GetComponent<Text>().text = "記録:" + length.ToString("F2") + "m";

                anim.Play();
                apploudSound.Play();
                playOnce = false;

                Record JSMrecords = new Record();
                JSMrecords = JSMrecords.LoadRecords();
                if (Math.Abs(JSMrecords.JSMfirst) > Math.Abs(length))
                {
                    JSMrecords.JSMthird = JSMrecords.JSMsecond;
                    JSMrecords.JSMsecond = JSMrecords.JSMfirst;
                    JSMrecords.JSMfirst = length;
                    JSMrecords.SaveRecords(JSMrecords);
                }
                else if (Math.Abs(JSMrecords.JSMsecond) > Math.Abs(length))
                {
                    JSMrecords.JSMthird = JSMrecords.JSMsecond;
                    JSMrecords.JSMsecond = length;
                    JSMrecords.SaveRecords(JSMrecords);
                }
                else if (Math.Abs(JSMrecords.JSMthird) > Math.Abs(length))
                {
                    JSMrecords.JSMthird = length;
                    JSMrecords.SaveRecords(JSMrecords);
                }

                RewardCar rewards = new RewardCar();
                rewards = rewards.LoadRewards();
                rewards.miniCarKey++;
                if (rewards.miniCarKey > MenuDirector.miniCarUnlockQuota)
                {
                    rewards.miniCarKey = 6;
                }

                if (rewards.buggyKey == MenuDirector.buggyUnlockQuota)
                {
                    rewards.buggyKey++;
                }

                if (rewards.truckKey == MenuDirector.truckUnlockQuota)
                {
                    rewards.truckKey++;
                }

                if (30 > Math.Abs(length))
                {
                    if (rewards.buggyKey <= MenuDirector.buggyUnlockQuota)
                    {
                        rewards.buggyKey++;
                    }
                    if (15 > Math.Abs(length))
                    {                        
                        if (rewards.truckKey <= MenuDirector.truckUnlockQuota)
                        {
                            rewards.truckKey++;
                        }
                    }
                }
                
                rewards.SaveRewards(rewards);
                CarUnlockCheck();


            }

        }
    }

    public void TimeAttackMode()
    {
        limit -= Time.deltaTime;
        timeLimit.GetComponent<Text>().text = "残り:" + limit.ToString("F2") + "秒";
        
        if(limit <= 0)
        {
            isGameOver = true;
        }

        if (!isGameOver)
        {
            length = this.car.transform.GetChild(0).position.x - startPos;
            this.distance.GetComponent<Text>().text = "走行距離:" + length.ToString("F2") + "m";
        }
        else
        {

            if (playOnce)
            {
                timeLimit.SetActive(false);
                CameraController.GameOverFlag();
                ObjectController.GameOverFlag(true);
                BackgroundController.GameOverFlag();
                CarController.GameOverFlag();
                pauseButton.SetActive(false);
                retryButton.SetActive(true);
                titleButton.SetActive(true);
                this.distance.GetComponent<Text>().text = "記録:" + length.ToString("F2") + "m";

                Record TAMrecords = new Record();
                TAMrecords = TAMrecords.LoadRecords();
                if (TAMrecords.TAMfirst < length)
                {
                    TAMrecords.TAMthird = TAMrecords.TAMsecond;
                    TAMrecords.TAMsecond = TAMrecords.TAMfirst;
                    TAMrecords.TAMfirst = length;
                    TAMrecords.SaveRecords(TAMrecords);
                }
                else if (TAMrecords.TAMsecond < length)
                {
                    TAMrecords.TAMthird = TAMrecords.TAMsecond;
                    TAMrecords.TAMsecond = length;
                    TAMrecords.SaveRecords(TAMrecords);
                }
                else if (TAMrecords.TAMthird > length)
                {
                    TAMrecords.TAMthird = length;
                    TAMrecords.SaveRecords(TAMrecords);
                }

                RewardCar rewards = new RewardCar();
                rewards = rewards.LoadRewards();
                if (rewards.miniCarKey <= MenuDirector.miniCarUnlockQuota)
                {
                    rewards.miniCarKey++;
                }

                if (rewards.sportsCarKey == MenuDirector.sportsCarUnlockQuota)
                {
                    rewards.sportsCarKey++;
                }

                if (rewards.f1CarKey == MenuDirector.f1CarUnlockQuota)
                {
                    rewards.f1CarKey++;
                }

                if (600 < length)
                {                    
                    if (rewards.sportsCarKey <= MenuDirector.sportsCarUnlockQuota)
                    {
                        rewards.sportsCarKey++;
                    }
                    if (800 < length)
                    {
                        if (rewards.f1CarKey <= MenuDirector.f1CarUnlockQuota)
                        {
                            rewards.f1CarKey++;
                        }
                    }
                }
                rewards.SaveRewards(rewards);
                anim.Play();
                apploudSound.Play();
                CarUnlockCheck();
                playOnce = false;
            }

        }
    }

    public static void GameOverFlag()
    {
        isGameOver = true;
    }

    public static void GameMode(int i)
    {
        gameMode = i;
    }

    public void RetryButton()
    {
        Time.timeScale = 1f;
        AdmobGamePlay.StartAd();
        ObjectController.GameOverFlag(false);
        SceneManager.LoadScene("GamePlayScene");
    }

    public void TitleButton()
    {
        Time.timeScale = 1f;
        AdmobGamePlay.StartAd();
        ObjectController.GameOverFlag(false);
        SceneManager.LoadScene("MenuScene");
    }

    public void PauseButton()
    {
        isPauseButtonPushed = !isPauseButtonPushed;
        if (isPauseButtonPushed)
        {
            Time.timeScale = 0f;
            pauseDisplay.transform.position = new Vector3(mainCamera.transform.position.x,
            mainCamera.transform.position.y,
            transform.position.z);

            pauseDisplay.SetActive(true);
            retryButton.SetActive(true);
            titleButton.SetActive(true);
            switch (bgmDice)
            {
                case 1:
                    //bgmAudio.PlayOneShot(gameBgm);
                    bgmAudio.volume = 0.1f;
                    break;
                case 2:
                    //bgmAudio.PlayOneShot(gameBgm2);
                    bgmAudio2.volume = 0.1f;
                    break;
                case 3:
                    //bgmAudio.PlayOneShot(gameBgm3);
                    bgmAudio3.volume = 0.1f;
                    break;
            }
            pauseButton.GetComponent<Image>().sprite =　playImage;
          
        }
        else
        {
            Time.timeScale = 1f;
            pauseDisplay.SetActive(false);
            retryButton.SetActive(false);
            titleButton.SetActive(false);
            switch (bgmDice)
            {
                case 1:
                    //bgmAudio.PlayOneShot(gameBgm);
                    bgmAudio.volume = 0.3f;
                    break;
                case 2:
                    //bgmAudio.PlayOneShot(gameBgm2);
                    bgmAudio2.volume = 0.3f;
                    break;
                case 3:
                    //bgmAudio.PlayOneShot(gameBgm3);
                    bgmAudio3.volume = 0.3f;
                    break;
            }
            pauseButton.GetComponent<Image>().sprite = pauseImage;
        }       
       
    }

    public static void GameStartFlag()
    {
        limit = 45;
        if (gameMode == 1)
        {
            Destroy(timeLimit);
        }
        else
        {
            timeLimit.SetActive(true);
            Destroy(stopLine);
        }
    }

    public void CarUnlockBackButton()
    {
        carunlockImage.SetActive(false);
        retryButton.GetComponent<Button>().interactable = true;
        titleButton.GetComponent<Button>().interactable = true;
    }

    public void CarUnlockCheck()
    {
        RewardCar rewards = new RewardCar();
        rewards = rewards.LoadRewards();
        if (rewards.sportsCarKey == MenuDirector.sportsCarUnlockQuota
            || rewards.miniCarKey == MenuDirector.miniCarUnlockQuota
            || rewards.buggyKey == MenuDirector.buggyUnlockQuota
            || rewards.truckKey == MenuDirector.truckUnlockQuota
            || rewards.f1CarKey == MenuDirector.f1CarUnlockQuota)
        {
            retryButton.GetComponent<Button>().interactable = false;
            titleButton.GetComponent<Button>().interactable = false;
            StartCoroutine(DelayMethod(2.0f, () =>
            {
                carunlockImage.SetActive(true);
                carUnlockSound.Play();
            }));
                
        }
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

}
