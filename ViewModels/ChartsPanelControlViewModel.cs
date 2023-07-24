using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using BoreholeCalculations.Models;
using CommunityToolkit.Mvvm.Messaging;
using System.Diagnostics;
using System.Threading;

namespace BoreholeCalculations.ViewModels
{
	public class ChartsPanelControlViewModel
	{
		BoreholeService _service;
		public ChartsPanelControlViewModel(BoreholeService service)
		{
			_service = service;
			WeakReferenceMessenger.Default.Register<Borehole>(this, UpdateBorehole);
			WeakReferenceMessenger.Default.Register<List<IBorehole>>(this, UpdateBoreholes);
			var token = new CancellationToken();
			_service.CalculatePessureInAllBoreholes(token, 100);
		}

		private void UpdateBorehole(object recipient, Borehole message)
		{
			if (message == null) return;
			var list = message.PressureByDepth.ToList();
			((LineSeries<KeyValuePair<double, double>>)SingleSeries[0]).Values = list;
			SingleSeries[0].Name = message.Name;
		}
		private void UpdateBoreholes(object recipient, List<IBorehole> message)
		{
			if (message == null) return;
			for (int i = 0; i < StackSeries.Count() && i < message.Count(); i++)
			{
				Debug.WriteLine($"I have: {message[i].Name}");
				var list = ((Borehole)message[i]).PressureByDepth.ToList();
				((StackedAreaSeries<KeyValuePair<double, double>>)StackSeries[i]).Values = list;
				StackSeries[i].Name = message[i].Name;
			}
		}
		public ISeries[] StackSeries { get; set; }
			= new ISeries[]
			{
				new StackedAreaSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(0, 255, 0), new SKColor(0, 0, 255) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(0, 255, 0), new SKColor(0, 0, 255) }) { StrokeThickness = 5 },                  GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
				new StackedAreaSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(255, 0, 0), new SKColor(255, 255, 0) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(255, 0, 0), new SKColor(255, 255, 0) }) { StrokeThickness = 5 },                  GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
				new StackedAreaSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(128, 0, 128), new SKColor(255, 0, 255) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(128, 0, 128), new SKColor(255, 0, 255) }) { StrokeThickness = 5 },                  GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
				new StackedAreaSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(139, 69, 19), new SKColor(245, 222, 179) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(139, 69, 19), new SKColor(245, 222, 179) }) { StrokeThickness = 5 },                  GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
				new StackedAreaSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(0, 255, 255), new SKColor(255, 165, 0) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{  new SKColor(0, 255, 255), new SKColor(255, 165, 0) }) { StrokeThickness = 5 },                  GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
			};

		public ISeries[] SingleSeries { get; set; }
			= new ISeries[]
			{
				new LineSeries<KeyValuePair<double, double>>
				{
					Values=new KeyValuePair<double, double>[]
					{
						new KeyValuePair<double, double>(3, 4),
						new KeyValuePair<double, double>(-2, 5),
						new KeyValuePair<double, double>(5, 1),
						new KeyValuePair<double, double>(-1, -3),
						new KeyValuePair<double, double>(2, 6),
						new KeyValuePair<double, double>(-4, 2),
						new KeyValuePair<double, double>(0, 0),
						new KeyValuePair<double, double>(-3, -5),
						new KeyValuePair<double, double>(6, 3),
						new KeyValuePair<double, double>(-5, 4)
					},
					Stroke = new LinearGradientPaint(new[]{ new SKColor(135, 206, 235), new SKColor(0, 0, 139) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{  new SKColor(135, 206, 235), new SKColor(0, 0, 139) }) { StrokeThickness = 5 },                  GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
			};
	}
}
