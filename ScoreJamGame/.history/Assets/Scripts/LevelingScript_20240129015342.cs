
using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelingScript : MonoBehaviour
{

    public float currLevel;
    public float maxLevel = 5.0f;
    private float currExp;

    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    public void updateLevel(){
        slider.value = currLevel / maxLevel;
    }
    public void Update() {
        if (currLevel >= maxLevel) {
            currLevel = 0;
            maxLevel += 1;
        }
    }
    // Update is called once per frame
    public void Start() {
        currLevel = 0.0f;
        updateLevel();
    }

}
