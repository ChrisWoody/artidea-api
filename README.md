# artidea-api
A simple Azure Function that scrapes http://artprompts.org/ to return a random art subject idea.

[![Build status](https://ci.appveyor.com/api/projects/status/kcb72tgyr29d5263?svg=true)](https://ci.appveyor.com/project/ChrisWoody/artidea-api)

## How To Use
You can call the API by navigating to the url https://chriswoodyfuncs.azurewebsites.net/api/artidea via your browser.

Or via code (let's use C#!):
```csharp
using System.Net;

using (var client = new WebClient())
{
    var idea = client.DownloadString("https://chriswoodyfuncs.azurewebsites.net/api/artidea");
    
    Console.WriteLine(idea);
}
```

**Important Things**<br>
I have no affiliation with http://artprompts.org/ but it is a awesome site if would like some ideas on what to create.<br>
And I've used https://jbt.github.io/markdown-editor/ to design this MD file.