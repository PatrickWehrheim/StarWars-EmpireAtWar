
public class MenuTree
{
    private MenuNode _rootMenu;

    public void Add(MenuType rootType, params MenuType[] menuType)
    {
        if (_rootMenu == null)
        {
            _rootMenu = new MenuNode(rootType);
            return;
        }

        foreach (MenuType type in menuType)
        {
            MenuNode newNode = new MenuNode(type);
            _rootMenu = Add(newNode, _rootMenu, rootType);
        }
    }

    private MenuNode Add(MenuNode newNode, MenuNode root, MenuType rootType)
    {
        if (root == null) return newNode;

        root = Find(root, rootType);
        if(root != null)
        {
            root.Add(newNode, root);
        }

        return root;
    }

    private MenuNode Find(MenuNode root, MenuType type)
    {
        if(root.Data == type) return root;

        foreach(MenuNode child in root.ChildNodes)
        {
            root = Find(child, type);
        }

        return root;
    }
}
