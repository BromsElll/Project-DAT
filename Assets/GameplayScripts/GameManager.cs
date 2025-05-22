using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioSource SoundTrack;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 10;
    public int scorePerGoodNote = 12;
    public int scorePerNiceNote = 16;

    public int currentMulti;
    public int multiTracker;
    public int[] multiThresholds;

    public int noMiss = 0;

    public Text scoreText;
    public Text multiText;
    public Text noMissText;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missedText, rankText, finalScoreText;

    public GameObject pauseMenu;
    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;

        scoreText.text = "Счёт: 0";
        currentMulti = 1;

        totalNotes = 99;

        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.Started = true;

                SoundTrack.Play();

                var spawner = FindFirstObjectByType<NoteSpawner>();
                if (spawner != null)
                {
                    spawner.Initialize(SoundTrack);
                    spawner.StartSpawning();
                }
                else
                {
                    Debug.LogWarning("NoteSpawner not found in scene!");
                }
            }
        }
        else
        {
            if (startPlaying && !resultsScreen.activeInHierarchy && SoundTrack.time >= SoundTrack.clip.length && !isPaused)
            {
                resultsScreen.SetActive(true);

                normalsText.text = normalHits.ToString();
                goodsText.text = goodHits.ToString();
                perfectsText.text = perfectHits.ToString();
                missedText.text = missedHits.ToString();

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;

                percentHitText.text = percentHit.ToString("F1") + "%";

                string rankVal = "F";

                if (percentHit > 40)
                {
                    rankVal = "D";
                    if (percentHit > 60)
                    {
                        rankVal = "C";
                        if (percentHit > 80)
                        {
                            rankVal = "A";
                            if (percentHit > 95)
                            {
                                rankVal = "S";
                            }
                        }
                    }
                }

                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
            }

        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMulti - 1 < multiThresholds.Length)
        {
            multiTracker++;

            if (multiThresholds[currentMulti - 1] <= multiTracker)
            {
                multiTracker = 0;
                currentMulti++;
            }
        }

        multiText.text ="x" + currentMulti;

        //currentScore += scorePerNote * currentMulti;
        scoreText.text = "Счёт: " + currentScore;

        noMiss++;
        noMissText.text = "Без лаж: " + noMiss;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMulti;
        NoteHit();

        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMulti;
        NoteHit();

        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerNiceNote * currentMulti;
        NoteHit();

        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        noMiss = 0;
        currentMulti = 1;
        multiTracker = 0;

        noMissText.text = "Без лаж: " + noMiss;
        multiText.text = "x" + currentMulti;

        missedHits++;
    }

    public void PauseGame()
    {
        isPaused = true;
        SoundTrack.Pause();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        SoundTrack.UnPause();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("3FirstSongScene");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("1Menu");
    }

    public void MemeLocation()
    {
        SceneManager.LoadScene("4Meme");
    }
}
