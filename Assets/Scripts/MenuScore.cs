using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBest;

    private void Start() {
        textBest.text = "Best: " + PlayerPrefs.GetInt("BestScore").ToString();
    }
}
