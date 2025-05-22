using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Story : MonoBehaviour
{
    public UnityEngine.UI.Text storyText;
    public string[] storyLines;
    public float typingSpeed = 0.05f;  // �������� ������ ������

    private int currentLine = 0;
    private bool isTyping = false;

    void Start()
    {
        StartCoroutine(TypeLine());
    }

    void Update()
    {
        if (Input.anyKeyDown && !isTyping)
        {
            if (currentLine < storyLines.Length - 1)
            {
                currentLine++;
                StartCoroutine(TypeLine());
            }
            else
            {
                SceneManager.LoadScene("3FirstSongScene");  // ������� �� ������ �����
            }
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        storyText.text = "";
        foreach (char letter in storyLines[currentLine])
        {
            storyText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}