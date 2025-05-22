using UnityEngine;
using UnityEngine.UI;

public class ChordController : MonoBehaviour
{

    public static ChordController instance;

    public string[] chords = { "A", "S", "D", "F" };
    public int ChordIndex = 0;

    public KeyCode keyPress0;
    public KeyCode keyPress1;
    public KeyCode keyPress2;
    public KeyCode keyPress3;

    public Text ChordText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateChordText(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyPress0)) { SetChord(0); Debug.Log("Pressed key 0"); }
        if (Input.GetKeyDown(keyPress1)) { SetChord(1); Debug.Log("Pressed key 1"); }
        if (Input.GetKeyDown(keyPress2)) { SetChord(2); Debug.Log("Pressed key 2"); }
        if (Input.GetKeyDown(keyPress3)) { SetChord(3); Debug.Log("Pressed key 3"); }
    }

    private void Awake()
    {
        instance = this;
    }

    public string GetChord()
    {
        return chords[ChordIndex];
    }

    void UpdateChordText()
    {
        if (ChordText != null)
        {
            ChordText.text = chords[ChordIndex];
        }
    }

    void SetChord(int index)
    {
        ChordIndex = index;
        UpdateChordText();
    }
}
