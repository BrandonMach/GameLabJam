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
        float newYPos = fill[1].transform.position.y +
            (fill[1].sizeDelta.y * slider.value)
            - (this.GetComponent<RectTransform>().sizeDelta.y);

        transform.position = new Vector2(transform.position.x, newYPos);
    }

    

}
