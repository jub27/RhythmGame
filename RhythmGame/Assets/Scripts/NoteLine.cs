using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteLine : MonoBehaviour
{
    [SerializeField]
    private RectTransform noteStartTransform;
    private Image image;
    private Vector3 noteStartPosition;

    private Color originColor;
    private Color activeColor;

    private void Awake()
    {
        noteStartPosition = noteStartTransform.position;
        image = GetComponent<Image>();
        originColor = image.color;
        activeColor = originColor;
        activeColor.a = 0.7f;
    }

    public void OnKeyInput()
    {
        image.color = activeColor;
    }

    public void SetNote(Note note)
    {
        note.transform.SetParent(this.transform);
        note.SetSize(Random.Range(100, 1000));
        note.SetPosition(noteStartPosition);
        note.StartDrop();
    }
}
