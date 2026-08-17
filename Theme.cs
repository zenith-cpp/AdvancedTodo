namespace AdvancedTodo;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using System.Text.Json;

// Readonly: its value cannot be changed

public static class Theme
{
    //! LIGHT THEME
    public static readonly Color lightThemeBG;
    public static readonly Color lightThemeFG = Color.Black;
    public static readonly Color lightThemeBorderColor;
    public static readonly Color lightThemeSidePanelBG;
    public static readonly Color lightThemeLabelMouseEnter;

    //! MISC.
    public static readonly Color questionFormBackgroundColor;
    public static readonly string universalFont = "Century Gothic";


    //! Dark Theme
    public static readonly Color darkThemeBG;
    public static readonly Color darkThemeFG = Color.White;
    public static readonly Color darkThemeBorderColor;
    public static readonly Color darkThemeSidePanelBG;
    public static readonly Color darkThemeLabelMouseEnter;

    // here comes the themes you can buy from the shop
    //! Dark Rose Theme
    public static readonly Color darkRoseThemeFG;
    public static readonly Color darkRoseThemeBG;
    public static readonly Color darkRoseThemeBorderColor;
    public static readonly Color darkRoseThemeCursorEnterBG;
    public static readonly Color darkRoseThemeSidePanelBG;
    public static readonly Color darkRoseThemeLabelMouseEnter;
    

    //! Black And Gold Theme
    public static readonly Color blackAndGoldThemeFG;
    public static readonly Color blackAndGoldThemeBG;
    public static readonly Color blackAndGoldThemeBorderColor;
    public static readonly Color blackAndGoldThemeCursorEnterBG;
    public static readonly Color blackAndGoldThemeSidePanelBG;
    public static readonly Color blackAndGoldThemeLabelMouseEnter;

    //! Black And Green Theme
    public static readonly Color blackAndGreenThemeFG;
    public static readonly Color blackAndGreenThemeBG;
    public static readonly Color blackAndGreenThemeBorderColor;
    public static readonly Color blackAndGreenThemeCursorEnterBG;
    public static readonly Color blackAndGreenThemeSidePanelBG;
    public static readonly Color blackAndGreenThemeLabelMouseEnter;


    

    static Theme()
    {
        lightThemeBG                      = ColorTranslator.FromHtml("#f5f4ff");
        darkThemeBG                       = ColorTranslator.FromHtml("#1e1e2e");
        darkThemeSidePanelBG              = ColorTranslator.FromHtml("#0f0f1e"); // slightly darker than 1e1e2e
        lightThemeSidePanelBG             = ColorTranslator.FromHtml("#ebe8ff");
        darkThemeBorderColor              = ColorTranslator.FromHtml("#2a2a4a");
        lightThemeBorderColor             = ColorTranslator.FromHtml("#d4d0e8");
        lightThemeLabelMouseEnter         = ColorTranslator.FromHtml("#777777");
        darkThemeLabelMouseEnter          = ColorTranslator.FromHtml("#333333");
        questionFormBackgroundColor       = ColorTranslator.FromHtml("#949494"); // Storing it here cause for some reason CS hates ColorTranslators
    
        darkRoseThemeFG                   = ColorTranslator.FromHtml("#af0000");
        darkRoseThemeBG                   = ColorTranslator.FromHtml("#333333");
        darkRoseThemeBorderColor          = ColorTranslator.FromHtml("#ff0000");
        darkRoseThemeCursorEnterBG        = ColorTranslator.FromHtml("#4a4a4a");
        darkRoseThemeSidePanelBG          = ColorTranslator.FromHtml("#242424");
        darkRoseThemeLabelMouseEnter      = ColorTranslator.FromHtml("#FF1A1A");
        
        blackAndGoldThemeFG               = ColorTranslator.FromHtml("#FFD700");
        blackAndGoldThemeBG               = ColorTranslator.FromHtml("#333333");
        blackAndGoldThemeBorderColor      = ColorTranslator.FromHtml("#9b8400");
        blackAndGoldThemeCursorEnterBG    = ColorTranslator.FromHtml("#4a4a4a");
        blackAndGoldThemeSidePanelBG      = ColorTranslator.FromHtml("#242424");
        blackAndGoldThemeLabelMouseEnter  = ColorTranslator.FromHtml("#FFE44D");

        blackAndGreenThemeFG              = ColorTranslator.FromHtml("#00c91b");
        blackAndGreenThemeBG              = ColorTranslator.FromHtml("#000000");
        blackAndGreenThemeBorderColor     = ColorTranslator.FromHtml("#008b13");
        blackAndGreenThemeCursorEnterBG   = ColorTranslator.FromHtml("#1a1a1a");
        blackAndGreenThemeSidePanelBG     = ColorTranslator.FromHtml("#0b0f0c");
        blackAndGreenThemeLabelMouseEnter = ColorTranslator.FromHtml("#00FF22");
    }
}