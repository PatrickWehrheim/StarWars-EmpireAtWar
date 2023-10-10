using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _chooseMenuCanvas;
    [SerializeField] private Canvas _creditsMenuCanvas;

    private MenuDirector _menuDirector;
    private MenuTree _menuTree;

    public static MenuController Instance;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        _menuDirector.Build(MenuType.MainMenu);
        _menuTree.Add(MenuType.MainMenu);
        _menuTree.Add(
            //Root Menu
            MenuType.MainMenu, 

            //Child Menus
            MenuType.TutorialMenu,
            MenuType.SinglePlayerMenu,
            MenuType.MultiplayerMenu,
            MenuType.LoadMenu,
            MenuType.OptionsMenu,
            MenuType.QuitGame);
    }
    private void Awake()
    {
        _menuDirector = new MenuDirector(new MainMenuBuilder(_mainMenuCanvas));
        _menuTree = new MenuTree();
    }

    public void ChangeMenu(MenuType menuType)
    {
        bool isChooseMenu = menuType == MenuType.TutorialMenu || menuType == MenuType.CampaignMenu ||
            menuType == MenuType.GalaxyCaptureMenu || menuType == MenuType.SkirmishMenu;

        if (isChooseMenu)
        {
            _mainMenuCanvas.gameObject.SetActive(false);
            _chooseMenuCanvas.gameObject.SetActive(true);
            _creditsMenuCanvas.gameObject.SetActive(false);
            _menuDirector.ChangeBuilder(new ChooseMenuBuilder(_chooseMenuCanvas));
        }
        else if (menuType == MenuType.CreditsMenu)
        {
            _mainMenuCanvas.gameObject.SetActive(false);
            _chooseMenuCanvas.gameObject.SetActive(false);
            _creditsMenuCanvas.gameObject.SetActive(true);
            _menuDirector.ChangeBuilder(new CreditsMenuBuilder(_creditsMenuCanvas));
        }
        else
        {
            _chooseMenuCanvas.gameObject.SetActive(false);
            _mainMenuCanvas.gameObject.SetActive(true);
            _creditsMenuCanvas.gameObject.SetActive(false);
            _menuDirector.ChangeBuilder(new MainMenuBuilder(_mainMenuCanvas));
        }

        _menuDirector.Build(menuType);
    }
}
