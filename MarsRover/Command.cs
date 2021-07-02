﻿using System;
namespace MarsRover
{
    public class Command
    {
        public string CommandType { get; set; }
        public int NewPostion { get; set; }
        public string NewMode { get; set; }


        public Command() { }

        public Command(string commandType)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
        }

        public Command(string commandType, int value)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            NewPostion = value;
        }

        public Command(string commandType, int value, string newMode)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType) || String.IsNullOrEmpty(newMode))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
                throw new ArgumentNullException(newMode, "Mode required");
            }
            NewMode = newMode;
            NewPostion = value;
            
            
            
        }

    }
}
