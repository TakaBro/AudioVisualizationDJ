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
            //Destroy(gameObject);
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Note1") || other.gameObject.CompareTag("Note2") || other.gameObject.CompareTag("Note3") || other.gameObject.CompareTag("Note4"))
        {
            if (lifeTime > other.gameObject.GetComponent<NoteHitDetector>().lifeTime)
            {
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
            }
            else
            {
                //Destroy(gameObject);
                this.gameObject.SetActive(false);
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
