using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationPanel : MonoBehaviour
{
    public LevelingScript levelingScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelingScript.currLevel >= levelingScript.maxLevel) {
            levelingScript.currLevel = 0;
            levelingScript.maxLevel += 1;
            gameObject.GetComponentInChildren<GameObject>().SetActive(true);
        }
    }
}
