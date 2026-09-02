using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidbody;
    public float flapStrength = 15f;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float lowerLimit = -15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive){
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        if (transform.position.y < lowerLimit && birdIsAlive)
        {
            birdIsAlive = false;
            if (logic != null)
            {
                logic.gameOver();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
