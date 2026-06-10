namespace AdvancedTodo;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;
using System.Text.Json;

// Readonly: its value cannot be changed

public static class Theme
{
    public static readonly Color lightThemeBG;
    public static readonly Color lightThemeFG = Color.Black;
    public static readonly Color darkThemeBG;
    public static readonly Color darkThemeFG = Color.White;
    public static readonly Color darkThemeBorderColor;
    public static readonly Color lightThemeBorderColor;
    public static readonly Color darkThemeSidePanelBG;
    public static readonly Color lightThemeSidePanelBG;
    public static readonly Color questionFormBackgroundColor;
    public static readonly string universalFont = "Segoe UI";

    // here comes the themes you can buy from the shop
    public static readonly Color darkRoseThemeFG;
    public static readonly Color darkRoseThemeBG;
    public static readonly Color darkRoseThemeBorderColor;
    public static readonly Color darkRoseThemeCursorEnterBG;

    public static readonly Color blackAndGoldThemeFG;
    public static readonly Color blackAndGoldThemeBG;
    public static readonly Color blackAndGoldThemeBorderColor;
    public static readonly Color blackAndGoldThemeCursorEnterBG;

    public static readonly Color blackAndGreenThemeFG;
    public static readonly Color blackAndGreenThemeBG;
    public static readonly Color blackAndGreenThemeBorderColor;
    public static readonly Color blackAndGreenThemeCursorEnterBG;


    

    static Theme()
    {
        lightThemeBG                    = ColorTranslator.FromHtml("#f5f4ff");
        darkThemeBG                     = ColorTranslator.FromHtml("#1e1e2e");
        darkThemeSidePanelBG            = ColorTranslator.FromHtml("#0f0f1e"); // slightly darker than 1e1e2e
        lightThemeSidePanelBG           = ColorTranslator.FromHtml("#ebe8ff");
        darkThemeBorderColor            = ColorTranslator.FromHtml("#2a2a4a");
        lightThemeBorderColor           = ColorTranslator.FromHtml("#d4d0e8");
        questionFormBackgroundColor     = ColorTranslator.FromHtml("#949494"); // Storing it here cause for some reason CS hates ColorTranslators
        // The themes you can buy from the shop
        darkRoseThemeFG                 = ColorTranslator.FromHtml("#810000");
        darkRoseThemeBG                 = ColorTranslator.FromHtml("#333333");
        darkRoseThemeBorderColor        = ColorTranslator.FromHtml("#520202");
        darkRoseThemeCursorEnterBG      = ColorTranslator.FromHtml("#4a4a4a");
        blackAndGoldThemeFG             = ColorTranslator.FromHtml("#FFD700");
        blackAndGoldThemeBG             = ColorTranslator.FromHtml("#333333");
        blackAndGoldThemeBorderColor    = ColorTranslator.FromHtml("#9b8400");
        blackAndGoldThemeCursorEnterBG  = ColorTranslator.FromHtml("#4a4a4a");
        blackAndGreenThemeFG            = ColorTranslator.FromHtml("#00c91b");
        blackAndGreenThemeBG            = ColorTranslator.FromHtml("#000000");
        blackAndGreenThemeBorderColor   = ColorTranslator.FromHtml("#008b13");
        blackAndGreenThemeCursorEnterBG = ColorTranslator.FromHtml("#1a1a1a");
    }
}