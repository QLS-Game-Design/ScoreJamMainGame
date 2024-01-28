
using UnityEngine;
using UnityEngine.UI;

public class LevelingScript : MonoBehaviour
{

    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    public void updateLevel(float currentValue, float maxValue){
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
