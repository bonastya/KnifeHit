using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameUI))]
public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    
    public int knifeCount;

    [Header("Knife Spawn")]
    [SerializeField]
    private GameObject KnifeObject;
    [SerializeField]
    private Vector2 KnifePosition;

    public  GameUI GameUI  { get; private set; }

    private void Awake()
    {
        Instance = this;
        GameUI = this.GetComponent<GameUI>();
    }

    private void Start()
    {
        GameUI.SetKnifes(knifeCount);
        DoKnife();
    }

    private void DoKnife()
    {
        knifeCount--;
        Instantiate(KnifeObject, KnifePosition, Quaternion.identity);
    }

    public void OnKnifeHit()
    {
        if (knifeCount > 0)
        {
            DoKnife();
        }
        else
        {
            startGameOwerSequence(true);
        }
    }


    public void startGameOwerSequence(bool win)
    {
        StartCoroutine("gameOwerSequence", win);
    }

    public IEnumerator gameOwerSequence(bool win)
    {
        if (win)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            RestartGame();
        }
        else
        {
            GameUI.ShowRestartButton();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}
