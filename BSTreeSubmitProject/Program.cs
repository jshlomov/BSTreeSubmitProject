using BSTreeSubmitProject.Models;
using BSTreeSubmitProject.Utils;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Threading.Channels;

namespace BSTreeSubmitProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //without bonus

            //Console.WriteLine("---Take from json ant cretae the tree---\n");
            //var defenceStrategies = JsonUtil.GetObjectsFromJson<DefenceStrategy>("defenceStrategiesBalanced.json");
            //DefenceStrategiesBST tree = new();
            //defenceStrategies.ForEach(tree.Insert);
            //Thread.Sleep(4000);
            //Console.WriteLine("Creted\n\n");

            //Thread.Sleep(1000);
            //Console.WriteLine("---print the tree:---\n\n");
            //tree.PreOrderTraversalPrint();
            //Thread.Sleep(4000);
            //Console.WriteLine("\n\n");

            //with bonus

            // take from json and insert to tree
            Console.WriteLine("---Take from json ant cretae the tree---\n");
            var defenceStrategies = JsonUtil.GetObjectsFromJson<DefenceStrategy>("defenceStrategies.json");
            DefenceStrategiesBST tree = new();
            defenceStrategies.ForEach(tree.Insert);
            Thread.Sleep(4000);
            Console.WriteLine("Creted\n\n");

            //print the tree
            Thread.Sleep(1000);
            Console.WriteLine("---print the not balanced tree:---\n\n");
            tree.PreOrderTraversalPrint();
            Thread.Sleep(4000);
            Console.WriteLine("\n\n");

            //balance the tree and print him
            Console.WriteLine("---Balance the tree and print him---\n");
            tree.BalanceTree();
            tree.PreOrderTraversalPrint();
            Thread.Sleep(4000);
            Console.WriteLine("\n\n");

            //print the tree with in order (List)
            Console.WriteLine("---print list with in order---\n");
            tree.InOrderTraversal().ForEach(Console.WriteLine);
            Thread.Sleep(4000);
            Console.WriteLine("\n\n");

            //cretae new json in bin folder
            Console.WriteLine("---Create new Json with the new tree---\n\n");
            var defSstrategies = tree.Serialize();
            JsonUtil.SetDefenceStrategiesJson(defSstrategies, "newDefenceStrategies.json");
            Thread.Sleep(4000);
            Console.WriteLine("Done\n\n");

            //get the threats to the program and print them (for tests)
            Console.WriteLine("---get the threats to the program---\n\n");
            var threats = JsonUtil.GetObjectsFromJson<Threat>("threats.json");
            threats.ForEach(t => Console.WriteLine(t + ", " + SerevityUtil.CalculateSeverity(t)));
            Thread.Sleep(4000);
            Console.WriteLine("Done\n\n");

            //Go through all the threats and activate the defenses
            Console.WriteLine("---activate defences---\n\n");
            checkThreatsAndActiveDefences(threats, tree);
            Console.WriteLine("\n\nDone\n");

        }

        public static void checkThreatsAndActiveDefences(List<Threat> threats, DefenceStrategiesBST defenceTree)
        {
            foreach (Threat threat in threats)
            {
                //get threat severity
                int severity = SerevityUtil.CalculateSeverity(threat);

                //check if severity < of min defence and print message
                if (severity < defenceTree.FindMinSeverity())
                {
                    Console.WriteLine("is severity Attack below the threshold.Attack is ignored");
                    continue;
                }

                //get threat defences
                List<string> defences = defenceTree.SearchPreOrder(severity);

                //check if there are no defence for this threat and print message
                if (!defences.Any())
                {
                    Console.WriteLine("No defence suitable was found! Brace for impact.");
                    continue;
                }

                //activate defences
                activeDefences(defences);
            }
        }

        private static void activeDefences(List<string> defences)
        {
            foreach (var defence in defences)
            {
                Console.WriteLine(defence);
                Thread.Sleep(2000);
            }
        }
    }
}
