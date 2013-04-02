using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Speech.Synthesis;

namespace Synthesizer
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				string content = Console.ReadLine();
				using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
				{
					if (content.Equals("q"))
						return;
					synthesizer.Speak(content);
				}
			}
		}
	}
}
