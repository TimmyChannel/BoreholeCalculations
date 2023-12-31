﻿using LiveChartsCore.SkiaSharpView;
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
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView.Painting.Effects;

namespace BoreholeCalculations.ViewModels
{
	public class ChartsPanelControlViewModel
	{
		BoreholeService _service;
		public ObservableCollection<string> Boreholes => (ObservableCollection<string>)_service.GetBoreholeList().Select(b => b.Name);
		public ChartsPanelControlViewModel(BoreholeService service)
		{
			_service = service;
			WeakReferenceMessenger.Default.Register<List<IBorehole>>(this, UpdateChartSeries);

		}


		private void UpdateChartSeries(object recipient, List<IBorehole> message)
		{
			if (message == null || message.Count <= 0) return;

			((LineSeries<KeyValuePair<double, double>>)SingleSeries[0]).Values = ((Borehole)message.Last()).PressureByDepth.ToList();
			SingleSeries[0].Name = message.Last().Name;

			foreach (var item in StackSeries)
			{
				item.Values = null;
			}
			for (int i = 0; i < StackSeries.Count() && i < message.Count(); i++)
			{
				Debug.WriteLine($"I have: {message[i].Name}");
				Debug.WriteLine($"{_service.GetBoreholeList().FirstOrDefault((c) => { if (c.Name == message[i].Name) return true; else return false; }).Name}");
				var list = ((Borehole)message[i]).PressureByDepth.ToList();
				((LineSeries<KeyValuePair<double, double>>)StackSeries[i]).Values = list;
				StackSeries[i].Name = message[i].Name;
			}
		}
		#region Axes Design
		public Axis[] XAxes1 { get; }
		  = new Axis[]
		  {
				new Axis
				{
					Name = "Глубина, м",
					NamePaint = new SolidColorPaint(new SKColor(229,229,229)),
					LabelsPaint = new SolidColorPaint(new SKColor(229,229,229)),
					TextSize = 14,
					SeparatorsPaint = new SolidColorPaint(new SKColor(229,229,229)) { StrokeThickness = 1 },
				}
		  };

		public Axis[] YAxes1 { get;  }
			= new Axis[]
			{
				new Axis
				{
					Name = "Давление, Па",
					NamePaint = new SolidColorPaint(new SKColor(229, 229, 229)),
					LabelsPaint = new SolidColorPaint(new SKColor(229, 229, 229)),
					TextSize = 14,
					SeparatorsPaint = new SolidColorPaint(new SKColor(229, 229, 229))
					{
						StrokeThickness = 1,
						PathEffect = new DashEffect(new float[] { 3, 3 })
					}
				}
			};	
		public Axis[] XAxes2 { get; }
		  = new Axis[]
		  {
				new Axis
				{
					Name = "Глубина, м",
					NamePaint = new SolidColorPaint(new SKColor(229,229,229)),
					LabelsPaint = new SolidColorPaint(new SKColor(229,229,229)),
					TextSize = 14,
					SeparatorsPaint = new SolidColorPaint(new SKColor(229,229,229)) { StrokeThickness = 1 },
				}
		  };

		public Axis[] YAxes2 { get;  }
			= new Axis[]
			{
				new Axis
				{
					Name = "Давление, Па",
					NamePaint = new SolidColorPaint(new SKColor(229, 229, 229)),
					LabelsPaint = new SolidColorPaint(new SKColor(229, 229, 229)),
					TextSize = 14,
					SeparatorsPaint = new SolidColorPaint(new SKColor(229, 229, 229))
					{
						StrokeThickness = 1,
						PathEffect = new DashEffect(new float[] { 3, 3 })
					}
				}
			};
		#endregion
		#region Series Design
		public ISeries[] StackSeries { get; set; }
			= new ISeries[]
			{
				new LineSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(0, 255, 0), new SKColor(0, 0, 255) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(0, 255, 0), new SKColor(0, 0, 255) }) { StrokeThickness = 5 },
					GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
				new LineSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(255, 0, 0), new SKColor(255, 255, 0) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(255, 0, 0), new SKColor(255, 255, 0) }) { StrokeThickness = 5 },
					GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
				new LineSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(128, 0, 128), new SKColor(255, 0, 255) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(128, 0, 128), new SKColor(255, 0, 255) }) { StrokeThickness = 5 },
					GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
				new LineSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(139, 69, 19), new SKColor(245, 222, 179) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{ new SKColor(139, 69, 19), new SKColor(245, 222, 179) }) { StrokeThickness = 5 },
					GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					}
				},
				new LineSeries<KeyValuePair<double, double>>
				{
					Stroke = new LinearGradientPaint(new[]{ new SKColor(0, 255, 255), new SKColor(255, 165, 0) }) { StrokeThickness = 4 },
					GeometryStroke = new LinearGradientPaint(new[]{  new SKColor(0, 255, 255), new SKColor(255, 165, 0) }) { StrokeThickness = 5 },
					GeometryFill = null,
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
					GeometryStroke = new LinearGradientPaint(new[]{  new SKColor(135, 206, 235), new SKColor(0, 0, 139) }) { StrokeThickness = 5 },
					GeometryFill = null,
					GeometrySize = 2,
					Fill=null,
					Mapping=(point, charPoint)=>
					{
						charPoint.PrimaryValue=point.Value;
						charPoint.SecondaryValue=point.Key;
					},
				},
			};
		#endregion
	}
}
