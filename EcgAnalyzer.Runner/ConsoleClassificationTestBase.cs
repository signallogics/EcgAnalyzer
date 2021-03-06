﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcgAnalyzer.Runner
{
    public abstract class ConsoleClassificationTestBase : IClassificationTest
    {
        public abstract void Run(WaveformModelParameters parameters);

        protected virtual void WriteExpectedVsPredicted(int expected, int predicted)
        {
            var message = expected == predicted ? "CORRECT" : "WRONG";

            Console.WriteLine("Expected = {0} || Predicted = {1} || {2}", expected, predicted, message);
        }

        protected virtual void WriteSpacer()
        {
            Console.WriteLine("-----------------------------------\n");
        }

        protected WaveformReading CreateWaveformReadingFromCsvTokens(string[] tokens)
        {
            var elapsedTime = TimeSpan.Parse(string.Format("0:{0}", tokens[0].Replace("'", "")));
            var millivolts = Double.Parse(tokens[1]);

            return new WaveformReading(elapsedTime, millivolts);
        }
    }
}
