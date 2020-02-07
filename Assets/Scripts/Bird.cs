using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float jumpMultipler;
    public float fallMultipler;
    public int score;
    public GameObject wing;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            FallDown();
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
            UpdateRotation(); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.tag.Equals("ScoreGate"))
        //{
        //    Debug.LogError(collision.collider.name + "   " + collision.collider.tag);
        //    score++;
        //}
        //else
        //{
        //}
        SceneManager.LoadScene("SampleScene");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("ScoreGate"))
        {
            score++;
        }
    }

    private void OnGUI()
    {
        var displayText = "Score: " + score
            + "\nPause - P";
        GUI.skin.label.fontSize = 50;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(0f, 0f, 250f, 250f), displayText);
    }

    void Jump()
    {
        rb.velocity = new Vector3(0, 1, 0) * jumpMultipler;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        //TODO
        //MoveWing();
        //wing.transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    void FallDown()
    {
        rb.velocity -= new Vector3(0, 1, 0) * fallMultipler;
    }

    void UpdateRotation()
    {
        transform.Rotate(new Vector3(0, 0, rb.velocity.y / 10));
    }

    //TODO
    void MoveWing()
    {
        wing.transform.eulerAngles = new Vector3(70, wing.transform.eulerAngles.y, wing.transform.eulerAngles.z);
    }
}
