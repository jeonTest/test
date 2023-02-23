using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ShowControllsInGame : MonoBehaviour
{
    [SerializeField] private string _control;
    [SerializeField] private string _actionName;
    [SerializeField] private Text _displayText;
    private SettingsManager _manager;

    void Start()
    {
        _manager = ModuleManager.GetModule<SettingsManager>();
    }

    private void Update()
    {
        _displayText.text = _manager.CurrentValueOfControl(_control, _actionName).Split("/").Last();
    }
}
