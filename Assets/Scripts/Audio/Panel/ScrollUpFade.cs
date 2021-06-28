using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUpFade : MonoBehaviour
{
    [SerializeField]
    private float velocity;

    // Update is called once per frame
    void Update()
    {
        //ScrollUp
        gameObject.GetComponent<Transform>().transform.position += new Vector3(0f, velocity * Time.deltaTime);

        //Fade
        StartCoroutine(FadeTo(0.0f, 5000.0f));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(gameObject.GetComponent<SpriteRenderer>().color.a, aValue, t));
            gameObject.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
}
