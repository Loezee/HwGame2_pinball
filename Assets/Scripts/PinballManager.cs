using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PinballManager : MonoBehaviour
{

    [SerializeField]
    TMP_Text scoreText;

    int score = 0;

    [SerializeField]
    GameObject ballObj;

    Vector3 ballStartPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballStartPos = ballObj.transform.position;

        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + score.ToString();
    }



    public void AddScore()
    {
        //add to score
        //do score effects maybe
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            score = 0;
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("Week2");
            //set the ball's position to its original position
            //ballObj.transform.position = ballStartPos;
        }
    }
}
