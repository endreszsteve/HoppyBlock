using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour 
{
    private static float time;
    private int timeText;
    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        time = 90.0f;
        text.text = time.ToString();
    }

    void Update()
    {
        if (GameManager.Instance == GameManager.IsPlaying())
        {
            time -= Time.fixedDeltaTime;
        }
        timeText = Mathf.FloorToInt(time);
        updateTimer();
    }

    void updateTimer()
    {
        text.text = timeText.ToString();
    }
}
