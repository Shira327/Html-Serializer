using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


var html = await Load("file:///C:/Shira/proggraming/html%20serial.izer%20project/html%20example/exam.html");

var cleanHtml = new Regex("\\s").Replace(html, "");

var htmlLines = new Regex("<(.*?)>").Split(cleanHtml).Where(s => s.Length > 0);

var htmlElement = "<div id=\"my-id\" class=\"my-class-1 my-class-2\" width=\"100%\"> text </div>";

var attributes = new Regex("([^\\s]*?)=\"(.*?)\"").Matches(htmlElement);

Console.ReadLine();

async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    var html = await response.Content.ReadAsStringAsync();
    return html;
}



// מחלקה לייצוג מאפיינים של HTML

