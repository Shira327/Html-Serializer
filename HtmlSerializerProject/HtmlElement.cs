using System;
using System.Collections.Generic;
using System.Text;

public class HtmlElement
{
    // Properties
    public string Id { get; set; }
    public string Name { get; set; }
    public Dictionary<string, string> Attributes { get; set; }
    public List<string> Classes { get; set; }
    public string InnerHtml { get; set; }
    public HtmlElement Parent { get; set; }
    public List<HtmlElement> Children { get; set; }

    // בונה
    public HtmlElement(string name, string id = null, string innerHtml = null)
    {
        Name = name;
        Id = id;
        InnerHtml = innerHtml;
        Attributes = new Dictionary<string, string>();
        Classes = new List<string>();
        Children = new List<HtmlElement>();
    }

    // Methods
    public void AddAttribute(string key, string value)
    {
        if (Attributes.ContainsKey(key))
        {
            Attributes[key] = value;
        }
        else
        {
            Attributes.Add(key, value);
        }
    }

    public void AddClass(string className)
    {
        if (!Classes.Contains(className))
        {
            Classes.Add(className);
        }
    }

    public void AddChild(HtmlElement child)
    {
        child.Parent = this;
        Children.Add(child);
    }

    public void RemoveChild(HtmlElement child)
    {
        if (Children.Remove(child))
        {
            child.Parent = null;
        }
    }

    public string Render()
    {
        // Building attributes
        var attributesBuilder = new StringBuilder();
        if (!string.IsNullOrEmpty(Id))
        {
            attributesBuilder.Append($" id=\"{Id}\"");
        }
        if (Classes.Count > 0)
        {
            attributesBuilder.Append($" class=\"{string.Join(" ", Classes)}\"");
        }
        foreach (var attribute in Attributes)
        {
            attributesBuilder.Append($" {attribute.Key}=\"{attribute.Value}\"");
        }

        // Building inner content
        var childrenHtml = new StringBuilder();
        foreach (var child in Children)
        {
            childrenHtml.Append(child.Render());
        }

        // Final HTML structure
        return $"<{Name}{attributesBuilder}>{InnerHtml}{childrenHtml}</{Name}>";
    }
}