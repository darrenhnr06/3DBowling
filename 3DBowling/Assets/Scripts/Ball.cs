using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{
    public float speed;
    private Rigidbody myBody;
    private bool thrown = false;
    public float horizontalSpeed;
    
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        BallMovement();
    }

    void BallMovement()
    {
        if(!thrown)
        {
            float xAxis = Input.GetAxis("Horizontal");
            Vector3 position = transform.position;
            position.x += xAxis * horizontalSpeed;
            transform.position = position;
        }
        if (!thrown && Input.GetKeyDown(KeyCode.Space))
        {
            thrown = true;
            myBody.isKinematic = false;
            myBody.velocity = new Vector3(0, 0, speed);
        }
    }

    private void FixedUpdate()
    {
        if(thrown && myBody.IsSleeping())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
