using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField]
    private Note notePrefab;
    [SerializeField]
    private NoteLine[] noteLines;
    private ObjectPool<Note> noteObjectPool;

    private float noteDropSpeed_;
    public float noteDropSpeed
    {
        get
        {
            return noteDropSpeed_;
        }
        private set
        {
            noteDropSpeed_ = value;
        }
    }

    public static NoteManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        noteObjectPool = new ObjectPool<Note>(notePrefab, 15);
        noteDropSpeed = 100;
    }

    private void Start()
    {
        MakeRandomNote();
    }

    private void MakeRandomNote()
    {
        Note note = noteObjectPool.GetObject();
        noteLines[Random.Range(0, noteLines.Length)].SetNote(note);
    }
}
