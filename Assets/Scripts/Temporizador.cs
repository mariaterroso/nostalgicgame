using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Temporizador : MonoBehaviour
{
    [SerializeField]
    public float timeValue = 600;

    public Text timerText;

    [SerializeField]
    float timeLeft = 600;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(timeValue > 0)
       {
            timeValue -= Time.deltaTime;
       }
       else
       {
            timeValue = 0;
       }
        DisplayTime(timeValue);

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
            
    }

    void DisplayTime(float timetodisplay)
    {
        if(timetodisplay < 0)
        {
            timetodisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timetodisplay / 60);
        float seconds = Mathf.FloorToInt(timetodisplay % 60);

        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }
}

