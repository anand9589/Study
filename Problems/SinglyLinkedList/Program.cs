﻿// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
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

SinglyLinkedList.LinkedList<char> linked = new SinglyLinkedList.LinkedList<char>();
linked.Push('a');
linked.Push('b');
linked.Push('c');
linked.Push('b');
linked.Push('b');

bool isPalindromw = linked.IsPalindrome();
Console.WriteLine(isPalindromw);

Console.WriteLine();
Console.WriteLine("==========Remove duplicate from sorted list=============");
SinglyLinkedList.LinkedList<int> sortedList = new SinglyLinkedList.LinkedList<int>();
sortedList.Push(11);
sortedList.Push(11);
sortedList.Push(11);
sortedList.Push(11);
sortedList.Push(13);
sortedList.Push(14);
sortedList.Push(14);
sortedList.Push(15);
sortedList.Push(15);
sortedList.Push(15);
sortedList.Print();
sortedList.RemoveDuplicatesFromSortedList();
Console.WriteLine();
sortedList.Print();
Console.WriteLine();
Console.WriteLine("=======================");
Console.WriteLine();