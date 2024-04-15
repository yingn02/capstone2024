using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class optionControl : MonoBehaviour
{
    public Light light;
    public ReflectionProbe reflectionProbe;
    public void control(float v)
    {
        AudioListener.volume = v;
    }

    public void brightnessControl(float v)
    {
        light.intensity = v;
        reflectionProbe.intensity = v*2f;
    }
}
