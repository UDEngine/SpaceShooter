using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject asteroid;
    public Vector3 spawnValues;

    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;
    public UIController uIController;

    private bool gameOver = false;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("main");
        }

    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(asteroid, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                break;
            }
        }

    }

    public void GameOver()
    {
        gameOver = true;
        uIController.ShowGameOverUI();
    }
}