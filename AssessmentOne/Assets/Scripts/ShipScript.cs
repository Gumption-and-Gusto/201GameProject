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
    void Start()
    {
        voiceLines = GetComponent<AudioSource>();
        //Random intro voice line
        commanderPortrait.alpha = 0;
        FadeInCommander();
        voiceLines.clip = lines[Random.Range(4, 8)];
        Invoke("SayLine", 0.5f);
        Invoke("FadeOutCommander", 0.5f + voiceLines.clip.length);

        //Unpause in case paused
        pauseScript.Unpause();
        rb = GetComponent<Rigidbody>();
        //Set ship starting position
        transform.position = new Vector3(-40,-20, 2200);
        startPosition = transform.position;
        if (startPosition == transform.position)//This if condition seems redundant given the previous line, however it prevented an occasional bug where force would be added twice
        {
            rb.AddRelativeForce(Vector3.up * engineSpeed);
        }
        //Settings these variables on Start resets them when the level is retried
        deathTimer = 1;
        winTimer = 1;
        body.GetComponent<Renderer>().enabled = true;
        sphere.GetComponent<Renderer>().enabled = true;
    }   

    void Update()
    {
        shipTransform = transform;
        //flight control starts after 3 seconds, giving player time to read name and listen to intro dialog, as well as get their bearings
        if (timer < 0 && deathTimerOn == false && pauseScript.paused == false) 
        {
            //movement
            mouseMoves = new Vector3(Input.GetAxis("Mouse X") * -1, Input.GetAxis("Mouse Y") * 7 / 3, 0);
            rb.AddForce(mouseMoves * Time.deltaTime * strafeSpeed * (PlayerPrefs.GetFloat("MouseSensitivity") + 1));
            //Eight if statements to control the movement thruster particle systems animations - one for each thruster
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
        else//ticking down control timer
        {
            timer -= Time.deltaTime;
        }
        //timer for death screen to appear after the explosion animation
        if (deathTimerOn == true && deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
        }
        //timer for victory screen to appear after the detonation animation
        if (winTimerOn == true && winTimer > 0)
        {
            winTimer -= Time.deltaTime;
            whiteout.alpha += Time.deltaTime;//nuclear whiteout effect
        }
        //booleans control these fade in and out statements for the commander's portrait
        if (commanderVisible && commanderPortrait.alpha < 1)
        {
            commanderPortrait.alpha += 10 * Time.deltaTime;
        }
        else if (!commanderVisible && commanderPortrait.alpha > 0)
        {
            commanderPortrait.alpha -= 5 * Time.deltaTime;
        }
        //Set music quiet during voice lines
        if (voiceLines.isPlaying && music.volume > 0.05f)
        {
            music.volume = 0.05f;
        }
        //fade music back up to player's preferred volume after voice line
        if (!voiceLines.isPlaying && music.volume < PlayerPrefs.GetFloat("MusicVolume"))
        {
            music.volume += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Stpo and hide the ship on collision
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        body.GetComponent<Renderer>().enabled = false;
        sphere.GetComponent<Renderer>().enabled = false;
        exhaust.Stop();
        //If collided with the target
        if (collision.gameObject == reactorStream && !deathTimerOn)
        {
            if (!winTimerOn)
            {
                //Detonation sound - bassy and satisfying
                SFXSource.clip = SFX[1];
                SFXSource.Play();
                //set a victory line and play it
                voiceLines.clip = lines[Random.Range(16, 20)];
                Invoke("SayLine", 2.1f);
                //Nuclear particle effect
                nuclearDetonation.Play();
            }
            winTimerOn = true;
        }
        else if (!winTimerOn) {
            //Crash sound - intentionally unsatisfying to make wins sound better by comparison
            SFXSource.clip = SFX[0];
            SFXSource.Play();
            deathTimerOn = true;
            //Set a random death line and play it
            voiceLines.clip = lines[Random.Range(0, 4)];
            Invoke("SayLine", 0.7f);
            //Crash animation
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
    //Before calling this function I set the apropriate voice line from the array
    void SayLine()
    {
        voiceLines.Play();
    }

    //Passing through this collider trigger plays a line that points out the upcoming target
    private void OnTriggerExit(Collider other)
    {
        if(other = reactorTrigger)
        {
            voiceLines.clip = lines[Random.Range(8, 12)];
            FadeInCommander();
            Invoke("SayLine", 0.5f);
            Invoke("FadeOutCommander", 0.5f + voiceLines.clip.length);
        }
    }
}
