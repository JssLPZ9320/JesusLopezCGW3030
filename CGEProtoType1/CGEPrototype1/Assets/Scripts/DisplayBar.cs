using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//must include to use the slider
using UnityEngine.UI;

public class DisplayBar : MonoBehaviour
{

    //slider for health bar since public can be set in inspector 
    public Slider slider;

    //gradient for the health bar
    public Gradient gradient;

    //image for the fill of the health bar
    public Image fill;

    //function to set the current value of hte slider

    public void SetValue(float value)
    {
        //set value of the slider
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


    //function t oset the max value of the slider

    public void SetMaxValue(float value)
    {
        slider.maxValue = value;

        //sets the max value of the slider to the value 
        slider.value = value;

        fill.color = gradient.Evaluate(1f);
    }
   
}
