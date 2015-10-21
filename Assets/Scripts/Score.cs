using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameManager gm;
    public AudioManager audio;

    public GameObject scoreText;
    public Canvas pause;
    int score = 0;
    private Text text;

    private static Score instance = null;
    public static Score Instance { get { return instance; } }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        text = scoreText.GetComponent<Text>();
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
        pause.enabled = false;
    }

    public void UpdateScore()
    {
        score += 10;
    }
}
