using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public float PanelsSpeed = 10;
    [SerializeField] private GameObject _target;
    [SerializeField] private CinemachineVirtualCamera _cam;

    [SerializeField] RectTransform TopPanel;
    [SerializeField] RectTransform BottomPanel;

    const float PanelHeight = 50;
    private float _topYVisible = 0;
    private float _topYHidden = 50;
    private float _bottomYVisible = 50;
    private float _bottomYHidden = 0;

    private float _topY = 50;
    private float _bottomY = 0;

    void Start()
    {
        StartCoroutine(StartCutScene());
    }

    void Update() {
        var curPosTop = TopPanel.anchoredPosition;
        var curPosBottom = BottomPanel.anchoredPosition;

        curPosTop.y = _topY;
        curPosBottom.y = _bottomY;

        TopPanel.anchoredPosition = Vector3.Slerp(TopPanel.anchoredPosition, curPosTop, Time.deltaTime * PanelsSpeed);
        BottomPanel.anchoredPosition = Vector3.Slerp(BottomPanel.anchoredPosition, curPosBottom, Time.deltaTime * PanelsSpeed);
    }

    private IEnumerator StartCutScene() {
        yield return new WaitForSeconds(0.5f);
        
        EventBus.Invoke(EventConstants.CUTSCENE_START, new CustomEvent());
        ShowPanels(true);

        var prevFollow = _cam.Follow;
        var prevLook = _cam.LookAt;
        _cam.Follow = _target.transform;
        _cam.LookAt = _target.transform;

        yield return new WaitForSeconds(3.0f);

        _cam.Follow = prevFollow;
        _cam.LookAt = prevLook;

        ShowPanels(false);

        EventBus.Invoke(EventConstants.CUTSCENE_END, new CustomEvent());
    }

    private void ShowPanels(bool visible) {
        _topY = visible ? _topYVisible : _topYHidden;
        _bottomY = visible ? _bottomYVisible : _bottomYHidden;
    }
    
}
