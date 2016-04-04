﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using IrcDotRT.Samples.Common;

namespace TwitterBot
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IrcBot bot = null;

            try
            {
                // Write information about program.
                Console.WriteLine(ProgramInfo.AssemblyTitle);
                Console.WriteLine("Version {0}", ProgramInfo.AssemblyVersion);
                Console.WriteLine(ProgramInfo.AssemblyCopyright);
                Console.WriteLine();

                // Create and run bot.
                bot = new TwitterBot();
                bot.Run();
            }
#if !DEBUG
            catch (Exception ex)
            {
                ConsoleUtilities.WriteError("Fatal error: " + ex.Message);
                Environment.ExitCode = 1;
            }
#endif
            finally
            {
                if (bot != null)
                    bot.Dispose();
            }
        }
    }
}