# CBat
A C# library that runs batch code and files inside C#.
## How to install
1. Download the latest .dll from the releases page

2. Add a reference inside your C# project. In Visual Studio, go to Project > Add Project Reference.

3. Click on Browse and find the CBat.dll file then click ok.

4. To use inside a C# file you reference it by typing ` using CBat; `

## How to use
1. First, make sure you reference CBat in your C# file ` using CBat; `

2. Put this inside of a void/method. ` BatchExecute bat = new BatchExecute(); `

Now you're done!

## What does what?
`bat.BatchCode();` - enter one batch line to execute inside the brackets.

`bat.BatchFile();` - enter the file path to a batch file inside the brackets.
