using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;
    private float jumpForce = 5f;
    private float gravityModifier = 1f;
    private float yLim = 14f;
    private bool gameOver;
    private float groundLim = 0f;
    public AudioClip jumpClip;
    public AudioClip explosionClip;
    public ParticleSystem explosionParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudioSource.PlayOneShot(jumpClip, 1);

        }

        if (transform.position.y > yLim)
        {
            transform.position = new Vector3(transform.position.x, yLim, transform.position.z);

        }

        if (transform.position.y < groundLim)
        {
            Debug.Log($"GAME OVER");
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision onCollider)
    {
        if (!gameOver)
        {
            Debug.Log(message: "GAME OVER");

            //Activa la explosion
            explosionParticleSystem.Play();
            playerAudioSource.PlayOneShot(explosionClip, 1);
            cameraAudioSource.Stop();


            gameOver = true;
        }


    }

}
