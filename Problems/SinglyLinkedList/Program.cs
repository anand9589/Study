﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
SinglyLinkedList.LinkedList<int> ts = new SinglyLinkedList.LinkedList<int>();
//ts.Print();
ts.Push(55);
ts.Push(68);
ts.Push(43);
ts.Push(61);
ts.Push(3);
ts.Print();
Console.WriteLine();
Console.WriteLine(ts.GetMiddleNode());

ts.Push(67);
ts.Print();
Console.WriteLine();
Console.WriteLine(ts.GetMiddleNode());