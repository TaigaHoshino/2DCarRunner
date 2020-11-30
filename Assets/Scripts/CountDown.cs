using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float time;
    string[] count = { "3", "2", "1", "GO!" };
    AudioSource countAudio;
    public AudioClip audio1;
    public AudioClip audio2;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        i = 0;
        countAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1.0f)
        {
            if (3 > i)
            {
                countAudio.PlayOneShot(audio1);
                gameObject.GetComponent<Text>().text = count[i];
            }
            else if(i == 3)
            {
                countAudio.PlayOneShot(audio2);
                gameObject.GetComponent<Text>().text = count[i];
                GameDirector.GameStartFlag();
                CarController.GameStartFlag();
            }
            else if(i == 5)
            {
                Destroy(gameObject);
            }
            time = 0;
            i++;
        }
    }
}
