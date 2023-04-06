using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemContent : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemSprite;
    private GameObject itemModel;
    private ARInteractionManager interactionManager;
    public string ItemName { set { itemName = value; } }
    public string ItemDescription {set => ItemDescription = value; }
    public Sprite ItemSprite {set => itemSprite = value; }
    public GameObject ItemModel {set => itemModel = value; }

    void Start()
    {
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text= itemName;
        transform.GetChild(1).GetComponent<Image>().sprite= itemSprite;
        transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = itemDescription;

        var button=GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition);
        button.onClick.AddListener(Instantiate3DModel);
        interactionManager=FindAnyObjectByType<ARInteractionManager>();
    }
    public void Instantiate3DModel()
    {
        interactionManager.ItemModel= Instantiate(itemModel);
    }
  
}
