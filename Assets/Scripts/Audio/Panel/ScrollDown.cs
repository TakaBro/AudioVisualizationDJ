using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour
{
    [SerializeField]
    private float beatTempo;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = 200 / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0f, beatTempo * Time.deltaTime);
    }
}
