using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class NoteSpawner : MonoBehaviour
{

    [System.Serializable]
    public class NoteData
    {
        public GameObject notePrefab;
        public float spawnTime;
        public Vector3 spawnPosition;
    }

    public List<NoteData> notesSpawn = new List<NoteData>();
    private int noteIndex = 0;

    public Transform noteHolder;

    private AudioSource audioSource;

    private bool songStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Loaded notes: " + notesSpawn.Count);


        if (audioSource == null)
        {
            Debug.Log("NO AudioSource");
        }
        else
        {
            Debug.Log("AudioSource IS HERE");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Suchiy Update is working");


        if (!songStarted || audioSource == null)
            return;

        //Debug.Log("Audio Time: " + audioSource.time);

        if (noteIndex < notesSpawn.Count)
        {
            NoteData currentNote = notesSpawn[noteIndex];

            if (audioSource.time >= currentNote.spawnTime)
            {
                GameObject note = Instantiate(currentNote.notePrefab, currentNote.spawnPosition, Quaternion.identity);

                Debug.Log("NoteSpawned");

                note.transform.SetParent(noteHolder, worldPositionStays: true);

                noteIndex++;
            }
        }
    }
    public void StartSpawning()
    {
        Debug.Log("Spawning started!");
        songStarted = true;
    }
    public void Initialize(AudioSource source)
    {
        audioSource = source;
    }
}
