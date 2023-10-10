using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MenuNode
{
    public MenuType Data;
    public MenuNode RootNode;
    public List<MenuNode> ChildNodes;

    public MenuNode(MenuType data)
    {
        Data = data;
        ChildNodes = new List<MenuNode>();
    }

    public void Add(MenuNode newNode, MenuNode root)
    {
        newNode.RootNode = root;
        ChildNodes.Add(newNode);
    }
}
