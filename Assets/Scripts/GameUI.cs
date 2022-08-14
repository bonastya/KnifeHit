using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    [SerializeField]
    private GameObject restartButton;

    [Header("Knife Count Display")]
    [SerializeField]
    private GameObject panelKnifes;
    [SerializeField]
    private GameObject iconKnife;
    [SerializeField]
    private Color usedKnifeColour;

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void SetKnifes(int count)
    {
        for(int i=0; i<count; i++)
        {
            Instantiate(iconKnife, panelKnifes.transform);
        }
    }

    private int knifeIndexToChange = 0;

    public void DecrementDisplatedKnifes()
    {
        panelKnifes.transform.GetChild(knifeIndexToChange++)
            .GetComponent<Image>().color = usedKnifeColour;
    }





}
