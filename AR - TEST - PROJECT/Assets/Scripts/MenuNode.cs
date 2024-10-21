using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNode : MonoBehaviour
{
    /*
     Node class --> This class represent each node of the menu
     In order to create a tree data structure for the main menu
     */

    public GameObject Screen { get; private set; }
    public MenuNode Parent { get; private set; }
    public List<MenuNode> Children { get; private set; }

    public MenuNode(GameObject menu)
    {
        Screen = menu;
        Children = new List<MenuNode>();
    }

    public void SetParent(MenuNode parent)
    {
        Parent = parent;
    }

    public void AddChild(MenuNode child, MenuNode father)
    {
        child.SetParent(this);

        Debug.Log("Filho: " + child.Screen.name + " // Pai: " + child.Parent.Screen.name);

        Children.Add(child);
    }
}
