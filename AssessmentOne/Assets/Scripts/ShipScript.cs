using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScript : MonoBehaviour
{
    float timer = 3;
    public float deathTimer = 1;
    public float winTimer = 1;
    bool deathTimerOn = false;
    bool winTimerOn = false;
    bool commanderVisible;
    Vector3 mouseMoves;
    [SerializeField]
    GameObject reactorStream;
    [SerializeField]
    float strafeSpeed;
    [SerializeField]
    float engineSpeed;
    Rigidbody rb;
    public Transform shipTransform;
    [SerializeField]
    ParticleSystem explosion;
    [SerializeField]
    ParticleSystem nuclearDetonation;
    [SerializeField]
    GameObject body;
    [SerializeField]
    GameObject sphere;
    [SerializeField]
    ParticleSystem exhaust;
    [SerializeField]
    CanvasGroup whiteout;
    [SerializeField]
    PauseScript pauseScript;
    [SerializeField]
    CanvasGroup commanderPortrait;
    public AudioClip[] lines;
    AudioSource audioSource;
    [SerializeField]
    Collider reactorTrigger;
    Vector3 startPosition = new(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        commanderPortrait.alpha = 0;
        FadeInCommander();
        audioSource.clip = lines[Random.Range(4, 7)];
        Invoke("SayLine", 0.5f);
        Invoke("FadeOutCommander", 0.5f + audioSource.clip.length);

        pauseScript.Unpause();
        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(-40,-20, 2200);
        startPosition = transform.position;
        if (startPosition == transform.position)
        {
            rb.AddRelativeForce(Vector3.up * engineSpeed);
        }
        deathTimer = 1;
        winTimer = 1;
        body.GetComponent<Renderer>().enabled = true;
        sphere.GetComponent<Renderer>().enabled = true;
    }   
    // Update is called once per frame
    void Update()
    {
        shipTransform = transform;
        if (timer < 0 && deathTimerOn == false && pauseScript.paused == false) 
        {
            mouseMoves = new Vector3(Input.GetAxis("Mouse X") * -1, Input.GetAxis("Mouse Y") * 7 / 3, 0);
            rb.AddForce(mouseMoves * Time.deltaTime * strafeSpeed);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (deathTimerOn == true && deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
        }
        if (winTimerOn == true && winTimer > 0)
        {
            winTimer -= Time.deltaTime;
            whiteout.alpha += Time.deltaTime;
        }
        if (commanderVisible && commanderPortrait.alpha < 1)
        {
            commanderPortrait.alpha += 10 * Time.deltaTime;
        }
        else if (!commanderVisible && commanderPortrait.alpha > 0)
        {
            commanderPortrait.alpha -= 5 * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        body.GetComponent<Renderer>().enabled = false;
        sphere.GetComponent<Renderer>().enabled = false;
        exhaust.Stop();
        if (collision.gameObject == reactorStream)
        {
            if (!winTimerOn)
            {
                nuclearDetonation.Play();
                audioSource.clip = lines[Random.Range(16, 19)];
                Invoke("SayLine", 2.1f);
            }
            winTimerOn = true;
        }
        else if (!winTimerOn) {
            explosion.Play();
            deathTimerOn = true;
            audioSource.clip = lines[Random.Range(0, 3)];
            Invoke("SayLine", 0.7f);
        }
    }

    public void FadeInCommander()
    {
        commanderVisible = true;
    }

    public void FadeOutCommander()
    {
        commanderVisible = false;
    }

    void SayLine()
    {
        audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other = reactorTrigger)
        {
            audioSource.clip = lines[Random.Range(8, 11)];
            FadeInCommander();
            Invoke("SayLine", 0.5f);
            Invoke("FadeOutCommander", 0.5f + audioSource.clip.length);
        }
    }
}
