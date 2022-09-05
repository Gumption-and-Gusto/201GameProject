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
    public float strafeSpeed;
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
    public AudioClip[] SFX;
    AudioSource voiceLines;
    [SerializeField]
    AudioSource SFXSource;
    [SerializeField]
    AudioSource music;
    [SerializeField]
    Collider reactorTrigger;
    [SerializeField]
    ParticleSystem steeringTop;
    [SerializeField]
    ParticleSystem steeringLeft;
    [SerializeField]
    ParticleSystem steeringBottom;
    [SerializeField]
    ParticleSystem steeringRight;
    [SerializeField]
    ParticleSystem steeringTL;
    [SerializeField]
    ParticleSystem steeringBL;
    [SerializeField]
    ParticleSystem steeringBR;
    [SerializeField]
    ParticleSystem steeringTR;
    Vector3 startPosition = new(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        voiceLines = GetComponent<AudioSource>();
        commanderPortrait.alpha = 0;
        FadeInCommander();
        voiceLines.clip = lines[Random.Range(4, 7)];
        Invoke("SayLine", 0.5f);
        Invoke("FadeOutCommander", 0.5f + voiceLines.clip.length);

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
            rb.AddForce(mouseMoves * Time.deltaTime * strafeSpeed * (PlayerPrefs.GetFloat("MouseSensitivity") + 1));
            if (mouseMoves.x < 0)
            {
                steeringLeft.Emit((int)((mouseMoves.x - 0.3) * -2));
            }
            if (mouseMoves.x > 0)
            {
                steeringRight.Emit((int)((mouseMoves.x + 0.3) * 2));
            }
            if (mouseMoves.y < 0)
            {
                steeringTop.Emit((int)((mouseMoves.y - 0.3) * -2));
            }
            if (mouseMoves.y > 0)
            {
                steeringBottom.Emit((int)((mouseMoves.y + 0.3) * 2));
            }
            if(mouseMoves.x < 0 && mouseMoves.y < 0)
            {
                steeringTL.Emit((int)((mouseMoves.y - 0.3) * 2) * (int)((mouseMoves.x - 0.3) * 2));
            }
            if (mouseMoves.x < 0 && mouseMoves.y > 0)
            {
                steeringBL.Emit((int)((mouseMoves.y + 0.3) * 2) * (int)((mouseMoves.x - 0.3) * -2));
            }
            if (mouseMoves.x > 0 && mouseMoves.y > 0)
            {
                steeringBR.Emit((int)((mouseMoves.y + 0.3) * 2) * (int)((mouseMoves.x + 0.3)*2));
            }
            if (mouseMoves.x > 0 && mouseMoves.y < 0)
            {
                steeringTR.Emit((int)((mouseMoves.y - 0.3) * -2) * (int)((mouseMoves.x + 0.3) * 2));
            }
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
        if (voiceLines.isPlaying && music.volume > 0.05f)
        {
            music.volume = 0.05f;
        }
        if (!voiceLines.isPlaying && music.volume < PlayerPrefs.GetFloat("MusicVolume"))
        {
            music.volume += Time.deltaTime;
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
                SFXSource.clip = SFX[1];
                SFXSource.Play();
                voiceLines.clip = lines[Random.Range(16, 19)];
                Invoke("SayLine", 2.1f);
                nuclearDetonation.Play();
            }
            winTimerOn = true;
        }
        else if (!winTimerOn) {
            SFXSource.clip = SFX[0];
            SFXSource.Play();
            deathTimerOn = true;
            voiceLines.clip = lines[Random.Range(0, 3)];
            Invoke("SayLine", 0.7f);
            explosion.Play();
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
        voiceLines.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other = reactorTrigger)
        {
            voiceLines.clip = lines[Random.Range(8, 11)];
            FadeInCommander();
            Invoke("SayLine", 0.5f);
            Invoke("FadeOutCommander", 0.5f + voiceLines.clip.length);
        }
    }
}
