using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;
    private Animator anim;
    public TMP_Text monolog;
    private string currentState;
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_DOWN = "downAnim";
    const string PLAYER_UP = "upAnim";
    const string PLAYER_LEFT = "leftAnim";
    const string PLAYER_RIGHT = "rightAnim";
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(speed * xAxis, speed * yAxis);
        if (yAxis > 0)
            changeAnim(PLAYER_UP);
        else if (yAxis < 0)
            changeAnim(PLAYER_DOWN);
        else if (xAxis < 0)
        {
            changeAnim(PLAYER_LEFT);
        }
        else if (xAxis > 0)
            changeAnim(PLAYER_RIGHT);
        else
            changeAnim(PLAYER_IDLE);

        
    }

    void changeAnim(string newState)
    {
        if (currentState == newState)
            return;

        anim.Play(newState);
        currentState = newState;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            monolog.text = "The sun will continue to attack the equator, turning it into a furnace that does not receive relief from the circulating ocean currents As vegetation dries, uncontrolled fires will rage in prairies, tundra and forests, reducing scarce food resources, producing more harmful greenhouse gases and depleting oxygen reserves.";
        }
        else if (collision.gameObject.tag == "Ship")
        {
            monolog.text = "It is estimated that about 37 million people earn their living at sea.When the water suddenly disappeared from under their feet, hapless sailors found themselves falling through the air. While swimmers and passengers on ships close to shore could escape with minor injuries, boats in the middle of the ocean faced a terrifying plunge to the seabed";
            Debug.Log("Ship");
        }
        else if (collision.gameObject.tag == "Fish")
            monolog.text = "Sea creatures that do not die immediately when they fall will quickly suffocate and die. All this organic material on the exposed seabed would begin to decompose. (ESTIMATED MARINE BIOMASS is 5-10 BILLION TONS).";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        monolog.text = "";
    }
}
