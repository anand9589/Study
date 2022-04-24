using StringProblems;

//"wordgoodgoodgoodbestword"
//["word", "good", "best", "good"]

//string str1 = "wordgoodgoodgoodbestword";
//string[] words = new string[] { "word", "good", "best", "good" };

//Solution solution = new Solution();
//var result = solution.FindSubstring(str1, words);
//Codec Codec = new Codec();
//var result = Codec.Encode("https://leetcode.com/problems/design-tinyurl");
//Console.WriteLine(result);

UndergroundSystem undergroundSystem = new UndergroundSystem();
undergroundSystem.CheckIn(45, "Leyton", 3);
undergroundSystem.CheckIn(32, "Paradise", 8);
undergroundSystem.CheckIn(27, "Leyton", 10);
undergroundSystem.CheckOut(45, "Waterloo", 15);
undergroundSystem.CheckOut(27, "Waterloo", 20);
undergroundSystem.CheckOut(32, "Cambridge", 22);
undergroundSystem.GetAverageTime("Paradise", "Cambridge");
