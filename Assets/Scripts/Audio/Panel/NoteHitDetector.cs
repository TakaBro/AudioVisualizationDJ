using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoteHitDetector : MonoBehaviour
{
    public static event Action onEnteredNoteHitMarker, onExitNoteHitMarker, onPerfectPressNote, onGoodPressNote;
    public float lifeTime = 0f;
    private bool _hasEnteredPerfectNoteHitMarker = false, _hasEnteredGoodNoteHitMarker = false;

    public float noteParticleXOffset;
    [SerializeField] private GameObject button, notePerfectParticle, noteGoodParticle, noteGreatComboSign, noteGoodComboSign, noteBadComboSign;
    [SerializeField] private string buttonNumber;

    private void Start()
    {
        button = GameObject.Find("/Canvas/Panel/Buttons/TouchButton (" + buttonNumber + ")");

        //button.GetComponent<IButtonController>().onButtonPressedInsideNoteHitMarker += SetNoteInactive;
    }

    private void OnDisable()
    {
        //button.GetComponent<IButtonController>().onButtonPressedInsideNoteHitMarker -= SetNoteInactive;
    }

    void Update()
    {
        lifeTime += Time.deltaTime;

        if (_hasEnteredPerfectNoteHitMarker && button.GetComponent<IButtonController>().ButtonPressingState())
        {
            onPerfectPressNote.Invoke();
            SetNoteInactive();
            //TO DO: Add notesParticles to ObjPool
            Instantiate(notePerfectParticle, new Vector3(noteParticleXOffset, this.gameObject.GetComponent<Transform>().transform.position.y + 10,
                                                  this.gameObject.GetComponent<Transform>().transform.position.z), Quaternion.identity);
            Instantiate(noteGreatComboSign, new Vector3(noteParticleXOffset, this.gameObject.GetComponent<Transform>().transform.position.y + 10,
                                                  this.gameObject.GetComponent<Transform>().transform.position.z), Quaternion.identity);
        }
        else if (_hasEnteredGoodNoteHitMarker && button.GetComponent<IButtonController>().ButtonPressingState())
        {
            onGoodPressNote.Invoke();
            SetNoteInactive();
            Instantiate(noteGoodParticle, new Vector3(noteParticleXOffset, this.gameObject.GetComponent<Transform>().transform.position.y + 8.5f,
                                                  this.gameObject.GetComponent<Transform>().transform.position.z), Quaternion.identity);
            Instantiate(noteGoodComboSign, new Vector3(noteParticleXOffset, this.gameObject.GetComponent<Transform>().transform.position.y + 8.5f,
                                                  this.gameObject.GetComponent<Transform>().transform.position.z), Quaternion.identity);
        }

    }

    private void SetNoteInactive()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PERFECTNoteHitMarker"))
        {
            //Debug.Log("OnTriggerEnter_PERFECTHitMarker");
            _hasEnteredPerfectNoteHitMarker = true;
            //onEnteredNoteHitMarker?.Invoke();
        }

        if (other.gameObject.CompareTag("GOODNoteHitMarker"))
        {
            //Debug.Log("OnTriggerEnter_GOODHitMarker");
            _hasEnteredGoodNoteHitMarker = true;
            //onEnteredNoteHitMarker?.Invoke();
        }

        if (other.gameObject.CompareTag("NoteButton"))
        {
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Note1") || other.gameObject.CompareTag("Note2") || other.gameObject.CompareTag("Note3") || other.gameObject.CompareTag("Note4"))
        {
            if (lifeTime > other.gameObject.GetComponent<NoteHitDetector>().lifeTime)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PERFECTNoteHitMarker"))
        {
            //Debug.Log("OnTriggerEXIT_PerfectHitMarker");
            _hasEnteredPerfectNoteHitMarker = false;
            //onExitNoteHitMarker?.Invoke();
        }

        if (other.gameObject.CompareTag("GOODNoteHitMarker"))
        {
            //Debug.Log("OnTriggerEXIT_GoodHitMarker");
            _hasEnteredGoodNoteHitMarker = false;
            //onExitNoteHitMarker?.Invoke();
        }
    }
}
