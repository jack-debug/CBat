# CBat
A C# library that runs batch files and Windows shell commands inside C#.
## How to install
1. Download the latest .dll from the releases page

2. Add a reference inside your C# project. In Visual Studio, go to Project > Add Project Reference.

3. Click on Browse and find the CBat.dll file then click ok.

4. To use inside a C# file you reference it by typing ` using CBat; `

## How to use
1. First, make sure you reference CBat in your C# file ` using CBat; `

2. Put this inside of a void/method. ` Execute bat = new Execute(); `

Now you're done!

## What does what?
`bat.Cmd();` - enter a cmd command to execute inside the brackets.

`bat.BatchFile();` - enter the file path to a batch file inside the brackets.

`bat.Bash();` - enter a bash command inside the brackets

`bat.PowerShellCmd` - enter a powershell command inside the brackets
