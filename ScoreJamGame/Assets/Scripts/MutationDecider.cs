using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class MutationDecider : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI text;

    public List<string> selections;
    public List<int> levels;

    public List<MutationDecider> scripts;

    [SerializeField]
    int randIndex;
    public Bullet bullet;
    public PlayerMovement playerMovement;

    public GameObject mutationPanel;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        allScripts<MutationDecider>();
        selections.AddRange(new List<string>{"Damage", "Health", "Mitosis", "Around"});
        levels.AddRange(new List<int>{0, 0, 0, 0});
        RandText();
    }

    void RandText() {
        System.Random random = new System.Random();
        randIndex = random.Next(selections.Count);
        foreach (MutationDecider script in scripts) {
            if (script.randIndex == this.randIndex) {
                RandText();
                break;
            }
        }
        text.text = selections[randIndex];
    }

    public void OnPointerClick(PointerEventData pointerEventData) {
        if (text.text == "Damage") {
            damageBuff();
        } else if (text.text == "Health") {
            healthBuff();
        } else if (text.text == "Mitosis") {
            // add swirling balls thing
        } else {
            // make attack also attack around you
        }
        mutationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void allScripts<T>() where T: MutationDecider {
		//TODO add selected to list of elements (to avoid using Find)
		GameObject[] gos = GameObject.FindGameObjectsWithTag("MutationButton");
		foreach (GameObject go in gos){
			T comp = go.GetComponent<T>(); 
			if (comp != null ) comp.scripts.Add(comp); 
		}
	}

    public void addSelection(string selection, int level) {
        foreach (MutationDecider script in scripts) {
            script.selections.Add(selection);
            script.levels.Add(level);
        }
    }

    public int getLevelIndex(string selection) {
        int index = 0;
        for (int i = 0; i < selections.Count; i++) {
            if (selections[i] == selection) {
                index = i;
            }
        }
        return index;
    }

    public void upgradeSelection(string selection) {
        int index  = getLevelIndex(selection);
        foreach (MutationDecider script in scripts) {
            script.levels[index]++;
        }
    }

    public void damageBuff() {
        upgradeSelection("Damage");
        int index = getLevelIndex("Damage");
        bullet.damage = 10 + 10*levels[index];
    }

    public void healthBuff() {
        int index = getLevelIndex("Health");
        upgradeSelection("Health");
        playerMovement.maxHealth = 100 + (20*levels[index]);
        playerMovement.currHealth += 20*levels[index];
    }

}
