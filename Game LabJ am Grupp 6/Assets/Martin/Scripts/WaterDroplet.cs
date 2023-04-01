using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDroplet : MonoBehaviour
{
    // Start is called before the first frame update

    private float timer = 0.4f;
    [SerializeField] private float timerReset = 0.4f;

    private Vector2 direction;

    [SerializeField] float speed = 1.1f;
    void Start()
    {
        direction = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(direction * Time.deltaTime * speed);

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction *= -1;
            timer = Random.Range(0.1f, timerReset);

        }
    }
}
