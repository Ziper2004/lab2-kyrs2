using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace StopWatch
{
    public class SWController
    {
        private readonly byte maxStopWathes;
        private readonly string pathRequest, pathResponse;
        private List<Stopwatch> stopwatches = new List<Stopwatch>();
        public SWController(byte maxStopWathes, string pathRequest, string pathResponse)
        {
            this.maxStopWathes = maxStopWathes;
            this.pathRequest = pathRequest;
            this.pathResponse = pathResponse;
        }
        private void Message(string message)
        {
            Console.WriteLine($"{message}");
            FileHandler.WriteData($"{message}", pathResponse);
        }
        private void Start()
        {
            if (stopwatches.Count == maxStopWathes)
                Message($"Кількість секундомірів не може перевищувати {maxStopWathes}!");
            else
            {
                stopwatches.Add(new Stopwatch());
                stopwatches[stopwatches.Count - 1].Start();
                Message($"Команда 'Start': {stopwatches.Count - 1}");
            }
        }
        private void Stop(byte id)
        {
            if (id < stopwatches.Count)
            {
                stopwatches[id].Stop();
                Message($"Команда 'Stop {id}': {stopwatches[id].ElapsedMilliseconds / 1000}");
            }
            else Message($"Неправильний ID. Значення індексу повинно бути в діапазоні [0, {maxStopWathes}] включно.");
        }
        private void Get(byte id)
        {
            if (id < stopwatches.Count)
            {
                stopwatches[id].Stop();
                Message($"Команда 'Get {id}': {stopwatches[id].ElapsedMilliseconds / 1000}");
            }
            else Message($"Неправильний ID. Значення індексу повинно бути в діапазоні [0, {maxStopWathes}] включно.");
        }
        private void Command(string command)
        {
            switch (command.Split()[0])
            {
                case "start":
                    Start();
                    break;
                case "stop":
                    Stop(byte.Parse(command.Split()[1]));
                    break;
                case "get":
                    Get(byte.Parse(command.Split()[1]));
                    break;
                case "exit":
                    Message("END!!!");
                    break;
                default:
                    break;
            }
        }
        public void CommandProcessing()
        {
            bool isExit = false;
             
            while (!isExit)
            {
                if (FileHandler.ExistsFile(pathRequest))
                {
                    Command(FileHandler.ReadLine(pathRequest));
                    FileHandler.DeleteFile(pathRequest);
                }
            }
        }
    }
}
