
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class LevelingScript : MonoBehaviour
{

    public float currLevel;
    public float maxLevel = 5.0f;
    private float currExp = 0.0f;

    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    public void updateLevel(){
        slider.value = currLevel / maxLevel;
    }
    public void Update() {
        if (currLevel >= maxLevel) {
            currLevel = 0;
            maxLevel += 1;
            currExp += 1;
        }
    }
    // Update is called once per frame
    public void Start() {
        currLevel = 0.0f;
        updateLevel();
        currExp = 0.0f;
    }

    public float getExp() {
        return currExp;
    }

}
