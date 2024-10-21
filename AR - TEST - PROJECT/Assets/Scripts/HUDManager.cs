using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{

    /*
     *    Script to handle all communication between HUD and System
     */
    [SerializeField]private ExperienceManager _expManager;

    [Header("Screens to build Tree")]
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject backScreen;

    private MenuNode root,backScreenNode;


    private void Start()
    {
        if(_expManager == null)
        {
            _expManager = GetComponent<ExperienceManager>();
        }
        BuildScreenTree(); // build tree
        NavigateTo(root); // Start navegation

    }

    //Simple Tree Configurations
    private void BuildScreenTree()
    {
        root = new MenuNode(startScreen);
        backScreenNode = new MenuNode(backScreen);
        root.AddChild(backScreenNode, root); //append first child

        MenuNode mainMenu = new MenuNode(startScreen);

        backScreenNode.AddChild(mainMenu, backScreenNode);   
    }
    private void NavigateTo(MenuNode target)
    {
        if (target.Screen != root.Screen)
        {
            if (target.Parent.Screen != null)
            {
                Debug.Log("Desativando tela passada: " + target.Parent.Screen.name);
                target.Parent.Screen.SetActive(false);
            }
            else
            {
                Debug.Log("Parent Screen is not defined, check the inspector!");
            }
        }
        else
        {
            Debug.Log("First root node");
            target.Children[0].Screen.SetActive(false);

        }
        target.Screen.SetActive(true);
    }

    //Button Configurations
    public void OnNextButtonPressed()
    {
        _expManager.PickNextObject();
    }
    public void OnPrevButtonPressed()
    {
        _expManager.PickNextObject();
    }
    public void OnChooseButtonPressed()
    {
        _expManager.ActivateSoloInfoPanel();
        NavigateTo(backScreenNode);
    }
    public void OnBackButtonPressed()
    {
        _expManager.ActivateSoloMenuPanel();
        NavigateTo(root);
    }
}
