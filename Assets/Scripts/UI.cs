using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI multiplierText;

    public void setMultiplier(int multiplier)
    {
        multiplierText.SetText("X {}", multiplier);
    }
}
