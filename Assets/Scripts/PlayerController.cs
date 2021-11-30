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
    private float gravityZero = 0;
    private float yLim = 14f;
    public bool gameOver;
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
            cameraAudioSource.Stop();
            Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            Instantiate(explosionParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
            playerAudioSource.PlayOneShot(explosionClip, 1f);

            cameraAudioSource.Stop();

            Physics.gravity *= gravityZero;

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;


            gameOver = true;
            Debug.Log(message: "GAME OVER");
        }


    }

}
