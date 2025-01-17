﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Save a number to a variable of type int and print it on the console
int number = 4;
Console.WriteLine(number);

//Save a text to a variable of type string and print it on the console
string text = "Hi there";
Console.WriteLine(text);

//Combine two variables of type int and print both
int numA = 3;
int numB = 6;
Console.WriteLine($"numA = {numA} and numB = {numB}");      //using string interpolation to construct string here

//Update a variable and print the new value
numA = 7;
Console.WriteLine($"numA updated to {numA}");

//Add two numbers and print the sum
Console.WriteLine(numA+numB);                               //Calculate value inline
Console.WriteLine("SUM: " + numA+numB);                     //using + to construct string here

//Combine two variables of different types and print it on the console
int numC = 5;
string hello = "Hello";
Console.WriteLine(hello + " " + numC);                      //using + to construct string here
Console.WriteLine($"{hello} {numC}");                       //using string interpolation to construct string here

//Print booleans (true/false), difference between string and bool?
string boolString = "true";
Console.WriteLine(boolString);

string boolStringCapitalT = "True";
Console.WriteLine(boolStringCapitalT);

bool boolBool = true;
Console.WriteLine(boolBool);                                //Console.WriteLine converts input to string before printing

//Read input from console
Console.WriteLine("Please enter a greeting and press [enter] to continue");
string? greeting = Console.ReadLine();                      //Reads a whole line (requires updating "console" property from "internalConsole" to "integratedTerminal" in .vscode/launch.json for debugging in vscode to work)
Console.WriteLine($"You wrote: {greeting}");

