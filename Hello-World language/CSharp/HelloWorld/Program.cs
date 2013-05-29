﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Performance
{
	public class Program
	{
		static void Main(string[] args)
		{
			Tester tester = new Tester();
			tester.Test(1000000);
			Console.ReadKey();
		}
	}

	public class Tester
	{
		public void Test(int n)
		{
			Source source = new Source();
			source.SourceEvent += EmptyMethod;
			source.SourceEvent += EmptyMethod2;

			Stopwatch watch = Stopwatch.StartNew();
			for (int i = 0; i < n; i++ )
			{
				source.TriggerEvent();
			}
			watch.Stop();
			Console.WriteLine(watch.Elapsed.ToString());

			Stopwatch watch2 = Stopwatch.StartNew();
			for (int i = 0; i < n; i++)
			{
				this.EmptyMethod(source, EventArgs.Empty);
			}
			watch2.Stop();
			Console.WriteLine(watch2.Elapsed.ToString());

			Stopwatch watch3 = Stopwatch.StartNew();
			for (int i = 0; i < n; i++)
			{
				source.TriggerEventWithHelper();
			}
			watch3.Stop();
			Console.WriteLine(watch3.Elapsed.ToString());

			Stopwatch watch4 = Stopwatch.StartNew();
			for (int i = 0; i < n; i++)
			{
				source.TriggerEventWithHelper2();
			}
			watch4.Stop();
			Console.WriteLine(watch4.Elapsed.ToString());
		}

		public void EmptyMethod(object sender, EventArgs e)
		{

		}

		public void EmptyMethod2(object sender, EventArgs e)
		{
		}
	}

	public class Source
	{
		public event EventHandler SourceEvent;

		public void TriggerEvent()
		{
			SourceEvent(this, EventArgs.Empty);
		}

		public void TriggerEventWithHelper()
		{
			EventHelper.Fire(SourceEvent, this, EventArgs.Empty);
		}

		public void TriggerEventWithHelper2()
		{
			EventHelper2.Fire(SourceEvent, this, EventArgs.Empty);
		}
	}

	public class EventHelper
	{
		public static void Fire(Delegate del, object sender, EventArgs e)
		{
			if (del == null)
				return;

			Delegate[] delegates = del.GetInvocationList();

			foreach (Delegate sink in delegates)
			{
				try
				{
					sink.DynamicInvoke(sender, e);
				}
				catch (Exception ex)
				{
					throw;
				}
			}
		}
	}

	public class EventHelper2
	{
		public static void Fire(EventHandler handler, object sender, EventArgs e)
		{
			handler(sender, e);
		}
	}
}
