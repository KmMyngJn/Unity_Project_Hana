using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int playerLife = 3, phase=1;
    float survivedTime;
    public Text phaseTxt, timeTxt, lifeTxt;
    GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        survivedTime = 0;
        lifeTxt.text = "���� ����ũ �� : " + (int)playerLife;
        phaseTxt.text = "������ : " + (int)phase;
        spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        survivedTime += Time.deltaTime;
        timeTxt.text = "�ð� : " + (float)survivedTime;
        if ((float)survivedTime / 30 >= phase)
        {
            phase = spawner.GetComponent<ddatSpawner>().addPhase();
            phaseTxt.text = "������ : " + (int)phase;
        }
    }

    public void getCake()
    {
        playerLife--;
        lifeTxt.text = "���� ����ũ �� : " + (int)playerLife;
        if (playerLife <= 0)
        {
            PlayerPrefs.SetFloat("Score", survivedTime);
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
