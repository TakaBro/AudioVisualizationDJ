using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoteHitDetector : MonoBehaviour
{
    public static event Action onHit;
    public float lifeTime = 0f;

    [SerializeField] private string _inputButtonNote;
    [SerializeField] private bool _hasEnteredNoteHitMarker = false;

    void Update()
    {
        lifeTime += Time.deltaTime;

        if (_hasEnteredNoteHitMarker && Input.GetButtonDown(_inputButtonNote))
        {
            Destroy(gameObject);
            onHit?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NoteHitMarker"))
        {
            //Debug.Log("OnTriggerEnter_HitMarker");
            _hasEnteredNoteHitMarker = true;
        }

        if (other.gameObject.CompareTag("NoteButton"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Note"))
        {
            if (lifeTime > other.gameObject.GetComponent<NoteHitDetector>().lifeTime)
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NoteHitMarker"))
        {
            //Debug.Log("OnTriggerEXIT_HitMarker");
            _hasEnteredNoteHitMarker = false;
        }
    }
}
