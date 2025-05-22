using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;
using UnityEngine.Audio;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defImage;
    public Sprite actImage;

    public KeyCode keyPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyPress))
        {
            Debug.Log("Audio Time: " + (GameManager.instance.SoundTrack.time - 5.87));
            theSR.sprite = actImage;
        }

        if (Input.GetKeyUp(keyPress))
        {
            theSR.sprite = defImage;
        }
    }
}
