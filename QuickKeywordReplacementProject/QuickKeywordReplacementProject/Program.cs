using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickKeywordReplacementProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] oldKeySet = { "level" };
            string[] newKeySet = { "device", "channel" };
            string s = ReplaceKeyWord(oldKeySet, newKeySet,
                "public ReactiveCommand<Unit, Unit> CancelLevelAddMode { get; }"
                );
            s = ReplaceKeyWord("group", "device", s);

            /*string s = ReplaceKeyWord("old", "new",
                "for (int i = 0; i < oldKeySet.Length; i++)\r\n            {\r\n                if (!String.IsNullOrWhiteSpace(oldKeySet[i]))\r\n                {\r\n                    AllLowerOldKeyBuilder.Append(oldKeySet[i].ToLower());\r\n                    AllUpperOldKeyBuilder.Append(oldKeySet[i].ToUpper());\r\n                    CamelOldKeyBuilder.Append(oldKeySet[i].Substring(0, 1).ToUpper());\r\n\r\n                    if (oldKeySet[i].Length > 1)\r\n                    {\r\n                        CamelOldKeyBuilder.Append(oldKeySet[i].Substring(1).ToLower());\r\n                    }\r\n\r\n                    if (i < oldKeySet.Length - 1)\r\n                    {\r\n                        CamelOldKeyBuilder.Append(\"_\");\r\n                    }\r\n                }\r\n            }"
                );*/
            Console.WriteLine(s);

            Console.ReadKey();
        }

        static string ReplaceKeyWord(string oldKey, string newKey, string s)
        {
            //e.g. eeeee
            string AllLowerOldKey = oldKey.ToLower();
            //e.g. Eeeee
            string CamelOldKey = oldKey.Substring(0, 1).ToUpper() + oldKey.Substring(1).ToLower();
            //e.g. EEEEE
            string AllUpperOldKey = oldKey.ToUpper();
            string AllLowerNewKey = newKey.ToLower();
            string CamelNewKey = newKey.Substring(0, 1).ToUpper() + newKey.Substring(1).ToLower();
            string AllUpperNewKey = newKey.ToUpper();

            return s.Replace(AllLowerOldKey, AllLowerNewKey)
                    .Replace(AllUpperOldKey, AllUpperNewKey)
                    .Replace(CamelOldKey, CamelNewKey);
        }

        static string ReplaceKeyWord(string[] oldKeySet, string[] newKeySet, string s)
        {
            //e.g. eeeee
            StringBuilder AllLowerOldKeyBuilder = new StringBuilder();
            //e.g. EEEEE
            StringBuilder AllUpperOldKeyBuilder = new StringBuilder();
            //e.g. EeeeeEeeee
            StringBuilder CamelOldKeyBuilder = new StringBuilder();
            StringBuilder AllLowerNewKeyBuilder = new StringBuilder();
            StringBuilder AllUpperNewKeyBuilder = new StringBuilder();
            StringBuilder CamelNewKeyBuilder = new StringBuilder();

            for (int i = 0; i < oldKeySet.Length; i++)
            {
                if (!String.IsNullOrWhiteSpace(oldKeySet[i]))
                {
                    AllLowerOldKeyBuilder.Append(oldKeySet[i].ToLower());
                    AllUpperOldKeyBuilder.Append(oldKeySet[i].ToUpper());

                    if (i < oldKeySet.Length - 1)
                    {
                        AllUpperOldKeyBuilder.Append("_");
                    }

                    CamelOldKeyBuilder.Append(oldKeySet[i].Substring(0, 1).ToUpper());

                    if (oldKeySet[i].Length > 1)
                    {
                        CamelOldKeyBuilder.Append(oldKeySet[i].Substring(1).ToLower());
                    }
                }
            }

            for (int i = 0; i < newKeySet.Length; i++)
            {
                if (!String.IsNullOrWhiteSpace(newKeySet[i]))
                {
                    AllLowerNewKeyBuilder.Append(newKeySet[i].ToLower());
                    AllUpperNewKeyBuilder.Append(newKeySet[i].ToUpper());

                    if (i < newKeySet.Length - 1)
                    {
                        AllUpperNewKeyBuilder.Append("_");
                    }

                    CamelNewKeyBuilder.Append(newKeySet[i].Substring(0, 1).ToUpper());

                    if (newKeySet[i].Length > 1)
                    {
                        CamelNewKeyBuilder.Append(newKeySet[i].Substring(1).ToLower());
                    }
                }
            }

            return s.Replace(AllLowerOldKeyBuilder.ToString(), AllLowerNewKeyBuilder.ToString())
                    .Replace(AllUpperOldKeyBuilder.ToString(), AllUpperNewKeyBuilder.ToString())
                    .Replace(CamelOldKeyBuilder.ToString(), CamelNewKeyBuilder.ToString());
        }
    }
}
