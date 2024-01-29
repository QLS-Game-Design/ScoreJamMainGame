using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text levelText;
    [SerializeField] LevelingScript levelingScript;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log()
        levelText.text = "Level: " + levelingScript.getExp().ToString();
    }
}
