using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public Text txtCooldown;

    public bool isTimeOver = false;
    public float countdownTimer = 60f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        GameCountdown();

        //Used for debugging
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    countdownTimer = 60f;

        //}

        if (isTimeOver == true)
        {
            SceneManager.LoadScene("Win");
        }

    }
    void GameCountdown()
    {
        //Subtrack time since last called
        countdownTimer -= Time.deltaTime;

        //Condition to make the text and the filler of the image active according to the status of the skill
        if (countdownTimer <= 0.0f)
        {
            isTimeOver = true;


            //txtCooldown.gameObject.SetActive(false);
            //imgCooldown.fillAmount = 0.0f;
        }
        else
        {
            txtCooldown.text = "Timer: " + Mathf.RoundToInt(countdownTimer).ToString();
            //txtCooldown.text = cooldownTimer.ToString();
            //imgCooldown.fillAmount = cooldownTimer / skill.skillCooldown;
        }
    }


}