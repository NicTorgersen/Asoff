using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Asoff.UI
{
    class Drawing
    {

        public static int defaultTopPosition = 3;

        public static int DrawMenuSelection(string[] items)
        {
            Console.WriteLine("Choose action with arrow keys:");

            int menuSelectedItemIndex = 0;
            int bottomOffset = 0;
            int topOffset = Console.CursorTop;
            bool loopComplete = false;
            ConsoleKeyInfo kb;

            Console.CursorVisible = false;

            while (!loopComplete)
            {

                for (int i = 0; i < items.Length; i++)
                {
                    if (i == menuSelectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("* " + items[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("* " + items[i]);
                    }
                }

                bottomOffset = Console.CursorTop;

                kb = Console.ReadKey(true);

                switch (kb.Key)
                {
                    case ConsoleKey.UpArrow:

                        if (menuSelectedItemIndex > 0)
                        {
                            menuSelectedItemIndex--;
                        }
                        else
                        {
                            menuSelectedItemIndex = (items.Length - 1);
                        }

                        break;

                    case ConsoleKey.DownArrow:

                        if (menuSelectedItemIndex < (items.Length - 1))
                        {
                            menuSelectedItemIndex++;
                        }
                        else
                        {
                            menuSelectedItemIndex = 0;
                        }

                        break;

                    case ConsoleKey.Enter:
                        
                        loopComplete = true;

                        break;

                }

                Console.CursorTop = topOffset;

            }

            Console.CursorVisible = true;

            return menuSelectedItemIndex;
        }

        public static void DrawLocationName(string locationName, bool dramatic = false)
        {
            ClearLine(0, 0, 0, 0);

            locationName = locationName.ToUpper();

            if (dramatic)
            {
                DramaticEffect("------ " + locationName + " ------");
            }
            else
            {
                Console.WriteLine("------ {0} ------", locationName);
            }

            Console.CursorTop = defaultTopPosition;
        }

        public static void DrawLocationDescription(string locationDescription, bool dramatic = false)
        {
            Console.CursorTop = 1;
            Console.CursorLeft = 3;
            if (dramatic)
            {
                DramaticEffect("- " + locationDescription);
            }
            else
            {
                Console.WriteLine("- {0}", locationDescription);
            }

            Console.CursorLeft = 0;
            Console.CursorTop = defaultTopPosition;
        }

        public static string AskInfo(string[] questions, string header, string fieldName, string type)
        {
            int bottomOffset = 0;
            int topOffset = Console.CursorTop;
            int leftOffset = 0;

            string information = "";
            
            Console.CursorVisible = false;
            
            ClearLinesAfter(0);

            DramaticEffects(questions);

            Console.WriteLine("");
            Console.WriteLine("-- {0} --", header.ToUpper());
            Console.Write(fieldName + " (" + type + "): ");

            bottomOffset = Console.CursorTop;

            while (information.Length < 4)
            {
                leftOffset = Console.CursorLeft;
                information = Console.ReadLine();
                Console.CursorTop = bottomOffset;
                Console.CursorLeft = leftOffset;
                if (information.Length > 3)
                {
                    topOffset = Console.CursorTop + 1;
                    leftOffset = 0;
                }
            }

            Console.CursorLeft = leftOffset;
            Console.CursorTop = topOffset;
            Console.CursorVisible = true;

            return information;
        }

        public static void DramaticEffects(string[] strArray, int waitTime = 500, bool shouldCleanup = false)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < strArray.Length; i++)
            {
                Thread.Sleep(waitTime);
                Console.WriteLine(strArray[i]);
            }

            if (shouldCleanup)
            {
                Thread.Sleep(waitTime*3);
                Console.Clear();
            }
            else
            {
                Thread.Sleep(waitTime);
            }

            Console.CursorVisible = true;
        }

        public static void DramaticEffect(string str, int waitTime = 500, bool shouldCleanup = false)
        {
            Console.CursorVisible = false;

            Thread.Sleep(waitTime);
            Console.WriteLine(str);

            if (shouldCleanup)
            {
                Thread.Sleep(waitTime*3);
                Console.Clear();
            }
            else
            {
                Thread.Sleep(waitTime);
            }

            Console.CursorVisible = true;
        }

        private static void ClearLine(int startPosLeft, int startPosTop, int left, int top) {
            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, startPosTop);
        }


        private static void ClearLinesAfter(int top)
        {
            for (int i = top; i < Console.WindowHeight; i++)
            {
                ClearLine(0, top, 0, i);
            }
        }

    }
}
