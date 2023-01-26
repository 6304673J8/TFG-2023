using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private int nextSceneToLoad;
    private int sceneToLoad;

    public int insertedCoins;

    private bool canPlay;

    [SerializeField]
    private GameObject _insertCoinPanel;

    [SerializeField]
    private GameObject _startGamePanel;

    [SerializeField]
    TextMeshProUGUI _insertCoinText;

    [SerializeField]
    private float FlickeringTimer;

    void Start()
    {
        StartCoroutine(FlickeringInsertCoinPanel());
        insertedCoins = 0;
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchScenes();
    }

    private void SwitchScenes()
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        switch (sceneToLoad)
        {
            case 0:
                InsertCoinSequence();
                if (Input.GetKeyDown(KeyCode.Space) && canPlay)
                    LoadInGameScene();
                break;
        }
    }

    private void LoadInGameScene()
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }

    void InsertCoinSequence()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            insertedCoins++;
            _insertCoinText.GetComponent<TextMeshProUGUI>().text = insertedCoins + " Coin(s)";
        }

        if (insertedCoins > 0)
        {
            _startGamePanel.gameObject.SetActive(true);
            canPlay = true;
        }
    }

    IEnumerator FlickeringInsertCoinPanel()
    {
        while (true)
        {
            Debug.Log(FlickeringTimer);
            if (_insertCoinPanel.activeInHierarchy)
                _insertCoinPanel.gameObject.SetActive(false);
            else
                _insertCoinPanel.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(FlickeringTimer);
        }
    }
}