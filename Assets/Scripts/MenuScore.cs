using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBest;

    // Display best score
    private void Start() {
        textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
    }
}
