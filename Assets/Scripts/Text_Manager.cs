using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Text_Manager : MonoBehaviour
{
    public TMP_Text text;
    public string str;
    bool isRunning;
    public RawImage image;
    public float target = 0.0f;
    public GameObject player;
    public float second = 2.0f;
    bool isStarted;
    private void Start()
    {
        isStarted = false;
        StartCoroutine(type());
    }

    private void Update()
    {
        Coroutine cor;
        if (isRunning == true)
            return;
        else if (!isStarted)
        {
            isStarted = true;
            image.canvasRenderer.SetAlpha(1.0f);
            FadeIn();
            cor = StartCoroutine(FadeTextToZeroAlpha(1.5f, text));

            if (cor != null)
            {
                movement();
            }
        }

        if (player.transform.position.y <= -1.5f)
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            SceneManager.LoadScene(5);
        }
    }
    private IEnumerator type()
    {
        text.text = "";
        isRunning = true;
        foreach (var item in str.ToCharArray())
        {
            text.text += item;
            yield return new WaitForSeconds(0.07f);
        }
        isRunning = false;
    }
    public IEnumerator FadeTextToZeroAlpha(float t, TMP_Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    public void FadeIn()
    {
        image.CrossFadeAlpha(0f, 1.0f, true);
    }

    public void movement()
    {
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        Animator anim = player.GetComponent<Animator>();
        rb.velocity = new Vector2(0f, -1f);
        anim.Play("downAnim");
        
    }
    
}
