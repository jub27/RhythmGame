using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteLine : MonoBehaviour
{
    [SerializeField]
    private RectTransform noteStartTransform;
    private Vector3 noteStartPosition;

    private void Awake()
    {
        noteStartPosition = noteStartTransform.position;
    }

    public void SetNote(Note note)
    {
        note.transform.SetParent(this.transform);
        note.SetSize(Random.Range(100, 1000));
        note.SetPosition(noteStartPosition);
        note.StartDrop();
    }
}
