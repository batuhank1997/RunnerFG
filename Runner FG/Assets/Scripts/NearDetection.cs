using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NearDetection : MonoBehaviour
{
    public Transform target;
    //public Transform parent;
    public Text scoreText;
    public GameObject nearMissText;
    public GameObject point100Text;
    public GameObject point500Text;
    private Vector3 offset;
    public int score = 0;

    private void Start()
    {
        offset = new Vector3(0, 0, 2);
    }
    private void Update()
    {
        if(target!= null)
        {
            transform.position = target.position + offset;
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
        if(score > 3000 && score < 7000)
        {
            GameController.I.generalSpeed = 70;
        }
        if (score > 7000 && score < 10000)
        {
            GameController.I.generalSpeed = 80;
        }
        if (score > 10000 && score < 12000)
        {
            GameController.I.generalSpeed = 90;
        }
        if (score > 12000 && score < 15000)
        {
            GameController.I.generalSpeed = 10;
        }
        if (score > 15000)
        {
            GameController.I.generalSpeed = 120;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            nearMissText.SetActive(true);
            if (GameController.I.feverMode == true)
            {
                point500Text.SetActive(true);
                score += 500;
            }
            else
            {
                point100Text.SetActive(true);
                score += 100;
            }
        }
        Invoke(nameof(Func), 0.5f);
        //Animation
    }
    void Func()
    {
        nearMissText.SetActive(false);
        point500Text.SetActive(false);
        point100Text.SetActive(false);
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(nearMissText, parent);
            if (GameController.I.feverMode == true)
            {
                Instantiate(point500Text, parent);
                score += 500;
            }
            else
            {
                Instantiate(point100Text, parent);
                score += 100;
            }
            Invoke(nameof(Func), 1);
        }
    }
    void Func()
    {
        Destroy(nearMissText);
        Destroy(point500Text);
        Destroy(point500Text);
    }*/
}
