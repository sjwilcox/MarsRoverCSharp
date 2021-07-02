using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; } = "NORMAL";
        public int Position { get; set; }
        public int GeneratorWatts { get; set; } = 110;

        public Rover(int position)
        {
            Position = position;
        }

        public void ReceiveMessage(Message message)
        {
            foreach(Command cmd in message.Commands)
            {
                try
                {
                    if (cmd.CommandType == "MODE_CHANGE")
                    {
                        Mode = cmd.NewMode;
                        if (Mode == "LOW_POWER")
                        {
                            Position = Position;
                        }
                        else
                        {
                            Position = cmd.NewPostion;
                        }

                    }
                    else if (cmd.CommandType == "MOVE")
                    {
                        Mode = cmd.NewMode;
                        if (Mode == "LOW_POWER")
                        {
                            Position = Position;
                        }
                        else
                        {
                            Position = cmd.NewPostion;
                        }
                    }
                    if (cmd.CommandType != "MODE_CHANGE" || cmd.CommandType != "MOVE")
                    {
                        throw new ArgumentOutOfRangeException(cmd.CommandType, "Invalid input");
                    }
                   
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"{ex}, invalid input");
                }
            }
        }
        

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
