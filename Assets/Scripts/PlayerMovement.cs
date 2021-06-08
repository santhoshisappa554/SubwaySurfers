using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    Animator anim;
    public Player localplayer;
    public float jumpSpeed;
    public int score;
    public Text ScoreText;
    public ParticleSystem particle;
    AudioSource audio;
    //public static int Coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        particle = GetComponent<ParticleSystem>();
        audio = GetComponent<AudioSource>();
        //Coins = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(0, 0, 1*playerSpeed)*Time.deltaTime;
        anim.SetTrigger("Run");
       
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(playerSpeed, 0, 0) * Time.deltaTime;
                 audio.Play();

        }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-playerSpeed, 0, 0) * Time.deltaTime;

            }
          else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0,playerSpeed*jumpSpeed, 0) * Time.deltaTime;
            anim.SetTrigger("Jump");
            //this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed*playerSpeed, 0));


        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0,-playerSpeed,0) * Time.deltaTime;

        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, localplayer.xMin, localplayer.xMax), Mathf.Clamp(transform.position.y, localplayer.yMin, localplayer.yMax), Mathf.Clamp(transform.position.z, localplayer.zMin, localplayer.zMax));
    }
    [System.Serializable]
    public class Player
    {
        public float xMin, xMax,yMin,yMax,zMin,zMax;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            score += 5;
            Destroy(collision.gameObject);
            print("Score: " + score);
            ScoreText.text = "Score:" + score;
           


        }
        else if (collision.gameObject.CompareTag("coin1"))
        {
            score += 100;
            Destroy(collision.gameObject);
            print("Score: " + score);
                ScoreText.text = "Score:" + score;

        }
    }
   

}
