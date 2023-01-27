using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public Vector3 jump;
    public float jumpForce;
    public Text ScoreText;

    Rigidbody rb;
    private int Score;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        rb = GetComponent<Rigidbody>();
        //jump = new Vector3(0.0f, 0.0f , 0.0f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = new Vector3(0, jumpForce);
        }         
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Bottom")
        {
            SceneManager.LoadScene("GameOver");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "goal")
        {
            Score += 10;
            ScoreText.text = "SCORE : " + Score;
        }
    }
}
