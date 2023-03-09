using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //
    }

    public void SetSize(float size)
    {
        rectTransform.sizeDelta = new Vector2(110, size);
    }

    public void SetPosition(Vector3 position)
    {
        rectTransform.position = position;
    }

    public void StartDrop()
    {
        StartCoroutine(AsyncDrop());
    }

    private IEnumerator AsyncDrop()
    {
        while (true)
        {
            yield return null;
            rectTransform.position += Vector3.down * NoteManager.instance.noteDropSpeed * Time.deltaTime;
        }
    }
}
