# sandbox-cshar

Step 0 : Discovery

I. Some commands ...
---

### A. Our first hello World

Open C# > New console project

Edit the first class : 

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.ReadLine();
        }
    }
}
```

### B. Loop example

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Tapoulet");
            Console.ReadLine();
        }
    }
}
```

NB : Use double tab shortcut to write for loop faster.

II. Snippet
---

Create file snipet.snippet : 

```xml
<?xml version="1.0" encoding="utf-8" ?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
  <CodeSnippet Format="1.0.0">
    <Header>
      <Title>Create string</Title>
      <Shortcut>helloString</Shortcut>
      <Description>Create hello string</Description>
      <Author>LDR</Author>
      <SnippetTypes>
        <!-- snippet types -->
        <SnippetType>Expansion</SnippetType>
      </SnippetTypes>
    </Header>
    <Snippet>
      <Declarations>
        <Literal>
          <ID>stringName</ID>
          <ToolTip>Choose a string name</ToolTip>
          <Default>stringName</Default>
        </Literal>
      </Declarations>
      <Code Language="csharp">
        <![CDATA[string $stringName$ = "Hello World !";]]>
      </Code>
    </Snippet>
  </CodeSnippet>
</CodeSnippets>
```

Tool > Import snippet > choose snippet

Tape helloString, double tab.

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Tapoulet");
            Console.ReadLine();


            string stringName = "Hello World !";
        }
    }
}
```

III. Class playground
---

### A. Our first class

Ctrl + Maj + A to create our first class named Animal

```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sandbox_csharp_step0
{
    class Animalcs
    {
    }
}

```

### B. Create abstract class who inherit from Animal

Source : https://fr.wikibooks.org/wiki/Programmation_C_sharp/H%C3%A9ritage_de_classes

