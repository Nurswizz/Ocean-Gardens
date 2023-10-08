using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_scirpt : MonoBehaviour
{
    RectTransform cam;
    public float speed = 400f;
    public float MIN_Y = -800f;
    public float MAX_Y = 0f;
    void Start()
    {
        cam = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        movement(MIN_Y, MAX_Y);
    }

    public void movement(float y_min, float y_max)
    {
        if (Input.GetKey(KeyCode.DownArrow) && cam.position.y <= y_max)
            cam.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        else if (Input.GetKey(KeyCode.UpArrow) && cam.position.y >= y_min)
            cam.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
    }
}
