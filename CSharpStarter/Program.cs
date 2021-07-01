using System;
using Speckle.Core.Kits;
using Speckle.Core.Credentials;
using Speckle.Core.Api;
using Objects;
using Speckle.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Objects.Geometry;
using Objects.Primitive;

namespace CSharpStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Speckle!");

            // Get default account on this machine
            var defaultAccount = AccountManager.GetDefaultAccount();

            // Create a new "base" object
            var commitObj = new Base();
            // Base objects are dynamic, so you can assign any properties just like a Dictionary
            commitObj["myProp"] = "myPropValue";
            commitObj["myOtherProp"] = new List<string> { "A", "list", "of", "values" };

            var boxes = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    boxes.Add(new Point(i, j, 0));
                }
            }
            commitObj["boxes"] = boxes;
            // Send the object to Speckle, get back the commit id
            var commitId = Helpers.Send("2d9b814ed6", commitObj, "Upload from my console app", null, 0, defaultAccount, false).Result;

            // To receive the latest commit
            var receivedObj = Helpers.Receive("2d9b814ed6", defaultAccount).Result;
            Console.WriteLine(receivedObj["myProp"]);
        }
    }
}
