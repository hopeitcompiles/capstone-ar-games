using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuCanvas;
    [SerializeField]
    private GameObject arPositionCanvas;
    private float doMoveValue;
    private float doMoveValueButton;
    private Transform aRListPositionTransform;
    private Transform aRButtonPositionTransform;
    private Transform menuOpenButtonTransform;
    private Transform menuCloseButtonTransform;
    private Scrollbar arListScrollbar;
    // Start is called before the first frame update
    private void Awake()
    {
        doMoveValue = 300;
        doMoveValueButton = 200;
        menuOpenButtonTransform = mainMenuCanvas.transform.GetChild(0).transform;
        menuCloseButtonTransform = mainMenuCanvas.transform.GetChild(1).transform;
        aRButtonPositionTransform = arPositionCanvas.transform.GetChild(0).transform;
        aRListPositionTransform = arPositionCanvas.transform.GetChild(1).transform;
        arListScrollbar = arPositionCanvas.transform.GetComponentInChildren<Scrollbar>();
        aRButtonPositionTransform.localScale = Vector3.zero;
        aRListPositionTransform.localScale = Vector3.zero;

    }
    void Start()
    {
        GameManager.instance.OnMainMenu+=ActivateMainMenu;
        GameManager.instance.OnItemsMenu+=ActivateARItemsMenu;
        GameManager.instance.OnARPosition+= ActivateARPosition;

       
    }

    private void ActivateMainMenu(){
        menuOpenButtonTransform.DOScale(new Vector3(1, 1, 1), 0.3f);
        menuCloseButtonTransform.DOScale(new Vector3(1, 1, 1), 0.3f);
        menuCloseButtonTransform.DOMoveX(doMoveValueButton, 0.3f);

        aRButtonPositionTransform.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        aRListPositionTransform.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        aRListPositionTransform.DOMoveY(doMoveValue, 0.3f);
    }
    
    private void ActivateARItemsMenu(){
        menuOpenButtonTransform.DOScale(new Vector3(0, 0, 0), 0.3f);
        menuCloseButtonTransform.DOScale(new Vector3(0, 0, 0), 0.3f);
        menuCloseButtonTransform.DOMoveX(doMoveValueButton / 2, 0.3f);

        aRButtonPositionTransform.DOScale(new Vector3(1, 1, 1), 0.3f);
        aRListPositionTransform.DOScale(new Vector3(1, 1, 1), 0.3f);
        aRListPositionTransform.DOMoveY(doMoveValue*1.7f, 0.3f);
        Debug.Log("before"+arListScrollbar.value);
        arListScrollbar.value = 0;
        Debug.Log("after" + arListScrollbar.value);
    }
    private void ActivateARPosition(){
        menuOpenButtonTransform.DOScale(new Vector3(1, 1, 1), 0.3f);
        menuCloseButtonTransform.DOScale(new Vector3(1, 1, 1), 0.3f);
        menuCloseButtonTransform.DOMoveX(doMoveValueButton, 0.3f);

        aRButtonPositionTransform.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        aRListPositionTransform.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        aRListPositionTransform.DOMoveY(doMoveValue, 0.3f);
    }
}
