using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTemp;

    public bool Started;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beatTemp = beatTemp / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started)
        {
            //if (Input.anyKeyDown)
            //{
            //    Started = true;
            //}
        }
        else
        {
            transform.position -= new Vector3( beatTemp * Time.deltaTime, 0f, 0f);
        }
    }
}
