using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    int scoreP1, scoreP2;
    Text scoreUIP1, scoreUIP2, txPemenang;
    GameObject panelSelesai;
    AudioSource audio;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        scoreP1 = 0;
        scoreP2 = 0;

        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();

        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);

        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlayOneShot(hitSound);
        if (collision.gameObject.name == "Pemukul1" || collision.gameObject.name == ("Pemukul2"))
        {
            float sudut = (transform.position.y - collision.transform.position.y)*5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }

        if (collision.gameObject.name == "TepiKanan")
        {
            scoreP1++;
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
            if (scoreP1 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Biru Pemenang!";
                Destroy(gameObject);
                return;
            }
        }
        if (collision.gameObject.name == "TepiKiri")
        {
            scoreP2++;
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
            if (scoreP2 == 5)
            {
                panelSelesai.SetActive(true);
                txPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                txPemenang.text = "Player Merah Pemenang!";
                Destroy(gameObject);
                return;
            }
        }
    }

    void TampilkanScore()
    {
        Debug.Log("Score P1: " + scoreP1 + ", Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
        TampilkanScore();
    }
}
