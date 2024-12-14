using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public static class HtmlTagHelper
{
    // רשימת תגיות HTML
    private static HashSet<string> HtmlTags;
    private static HashSet<string> HtmlVoidTags;

    public static object JsonSerializer { get; private set; }

    // טעינת תגיות מתוך JSON
    static HtmlTagHelper()
    {
        // טוען את הנתונים מתוך קבצים
        LoadTagsFromJson();
    }

    private static void LoadTagsFromJson()
    {
        try
        {
            // קריאת קובצי JSON מהדיסק (ניתן לשנות את הנתיב)
            string allTagsJson = File.ReadAllText("HtmlTags.json");
            string selfClosingTagsJson = File.ReadAllText("HtmlVoidTags.json");

            // פרסונם לתוך HashSet
            HtmlTags = JsonSerializer.Deserialize<HashSet<string>>(HtmlTags.json);
            HtmlVoidTags = JsonSerializer.Deserialize<HashSet<string>>(HtmlVoidTags.json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading tags from JSON: " + ex.Message);
            HtmlTags = new HashSet<string>();
            HtmlVoidTags = new HashSet<string>();
        }
    }

    // פונקציה לבדיקת קיום תגית
    public static bool IsValidTag(string tagName)
    {
        return HtmlTags.Contains(tagName);
    }

    // פונקציה לבדוק אם תגית היא Self-Closing
    public static bool IsSelfClosingTag(string tagName)
    {
        return HtmlVoidTags.Contains(tagName);
    }

    // קבלת כל התגיות
    public static IEnumerable<string> GetAllTags()
    {
        return HtmlTags;
    }

    // קבלת כל ה-Self-Closing Tags
    public static IEnumerable<string> GetSelfClosingTags()
    {
        return HtmlVoidTags;
    }
}