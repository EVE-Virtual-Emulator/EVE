﻿global using EVE.Components;
global using EVE.Models;

namespace EVE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            byte[] program =
            {
                0x01, 0x05,  // Load 5 into R0
                0x01, 0x17,  // Load 7 into R1
                0x03, 0x01,  // Add R0 and R1 and store in R0
                0x08, 0x00,  // Increment R0
                0x0D         // Halt
            };

            CPU cpu = new CPU();
            cpu.LoadProgram(program);
            cpu.Run(true);
            Console.ReadLine();
        }
    }
}