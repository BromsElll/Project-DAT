using UnityEngine;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyPress;

    public string CorrectChord;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    private static float lastPressTime = -1f;
    private const float pressCooldown = 0.01f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(keyPress))
        {
            if (Time.time - lastPressTime < pressCooldown) return;

            if (canBePressed && ChordController.instance.GetChord() == CorrectChord)
            {
                lastPressTime = Time.time;

                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.x + 8f) >= 0.25f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.x + 8f) >= 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            Debug.Log("Missed Note Effect");
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
