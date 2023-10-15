using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIConnector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lifeText;

    public void SetLife(float life) {
        _lifeText.text = life.ToString();
    }
}
