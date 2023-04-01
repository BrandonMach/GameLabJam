using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveFish : MonoBehaviour
{
    public Slider slider;
    public RectTransform[] fill;
    // Start is called before the first frame update
    private void Start()
    {
        fill = slider.GetComponentsInChildren<RectTransform>();
    }
    private void Update()
    {
        float newYPos = slider.transform.position.y -
            (slider.GetComponent<RectTransform>().sizeDelta.y * slider.value)
            + (slider.GetComponent<RectTransform>().sizeDelta.y / 2)
            /*- ((this.GetComponent<RectTransform>().sizeDelta.y) / 1.5f)*/;

        transform.position = new Vector2(transform.position.x, newYPos);
    }

    

}
