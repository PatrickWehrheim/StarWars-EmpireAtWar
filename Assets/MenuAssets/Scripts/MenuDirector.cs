using UnityEngine;

public class MenuDirector
{
    private IMenuBuilder _menuBuilder;

    public MenuDirector(IMenuBuilder menuBuilder)
    {
        _menuBuilder = menuBuilder;
    }

    public void ChangeBuilder(IMenuBuilder menuBuilder)
    {
        _menuBuilder = menuBuilder;
    }

    public void Build(MenuType type)
    {
        switch (type)
        {
            case MenuType.MainMenu:
                BuildMainMenu();
                break;
            case MenuType.SinglePlayerMenu:
                BuildSinglePlayerMenu();
                break;
            case MenuType.MultiplayerMenu:
                BuildMultiPlayerMenu();
                break;
            case MenuType.LoadMenu:
                break;
            case MenuType.OptionsMenu:
                BuildOptionsMenu();
                break;
            case MenuType.CreditsMenu:
                BuildCreditsMenu();
                break;
            case MenuType.QuitGame:
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit(0);
            #endif
                break;
            case MenuType.CampaignMenu:
                break;
            case MenuType.GalaxyCaptureMenu:
                break;
            case MenuType.SkirmishMenu:
                break;

        }
    }

    private void BuildMainMenu()
    {
        _menuBuilder.Reset();
        _menuBuilder.BuildHeaderText("Hauptmenü");
        _menuBuilder.BuildButton("Tutorial", MenuType.TutorialMenu);
        _menuBuilder.BuildButton("Einzelspieler", MenuType.SinglePlayerMenu);
        _menuBuilder.BuildButton("Mehrspieler", MenuType.MultiplayerMenu);
        _menuBuilder.BuildButton("Spiel Laden", MenuType.LoadMenu);
        _menuBuilder.BuildButton("Optionen", MenuType.OptionsMenu);
        _menuBuilder.BuildButton("Spiel Verlassen", MenuType.QuitGame);
    }

    private void BuildSinglePlayerMenu()
    {
        _menuBuilder.Reset();
        _menuBuilder.BuildHeaderText("Einzelspieler");
        _menuBuilder.BuildText("", 26);
        _menuBuilder.BuildButton("Kampagne", MenuType.CampaignMenu);
        _menuBuilder.BuildButton("Gal. Eroberung", MenuType.GalaxyCaptureMenu);
        _menuBuilder.BuildButton("Gefecht", MenuType.SkirmishMenu);
        _menuBuilder.BuildText("", 26);
        _menuBuilder.BuildButton("Zurück", MenuType.MainMenu);
    }

    private void BuildMultiPlayerMenu()
    {
        _menuBuilder.Reset();
        _menuBuilder.BuildHeaderText("Mehrspieler");
        _menuBuilder.BuildText("", 26);
        _menuBuilder.BuildButton("Internet", MenuType.CampaignMenu);
        _menuBuilder.BuildButton("LAN", MenuType.GalaxyCaptureMenu);
        _menuBuilder.BuildButton("Optionen", MenuType.SkirmishMenu);
        _menuBuilder.BuildText("", 26);
        _menuBuilder.BuildButton("Zurück", MenuType.MainMenu);
    }

    private void BuildOptionsMenu()
    {
        _menuBuilder.Reset();
        _menuBuilder.BuildHeaderText("Optionen");
        _menuBuilder.BuildButton("Soundoptionen", MenuType.CampaignMenu);
        _menuBuilder.BuildButton("Grafikoptionen", MenuType.CampaignMenu);
        _menuBuilder.BuildButton("Tastertur", MenuType.GalaxyCaptureMenu);
        _menuBuilder.BuildButton("Spiel", MenuType.SkirmishMenu);
        _menuBuilder.BuildButton("Credits", MenuType.CreditsMenu);
        _menuBuilder.BuildButton("Zurück", MenuType.MainMenu);
    }

    private void BuildCreditsMenu()
    {
        _menuBuilder.Reset();
        _menuBuilder.BuildHeaderText("Credits");
        _menuBuilder.BuildText("Space Skyboxes created by Raestream Graphics: From Unity Asset Store - 4K_Space_Skyboxes", 16);
        _menuBuilder.BuildText("Spaceship Models created by Free Game Assets: From Itch.io - Battle-SpaceShip-Free-3D-Low-Poly-Models", 16);
        _menuBuilder.BuildText("Spacestations created by Viktor Hahn: From Itch.io - Spacestations", 16);
        _menuBuilder.BuildText("Gras Texture created by LowlyPoly: From Unity Asset Store - Hand Painted Grass Texture", 16);
        _menuBuilder.BuildText("Rock Texture created by CrazyTextures: From Unity Asset Store - Rock 01", 16);
        _menuBuilder.BuildText("Space Kit (Buildings and People Models) created by Kenney: From Kenney.nl - Space Kit", 16);
        _menuBuilder.BuildButton("Zurück", MenuType.MainMenu);
    }
}
