using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace BoreholeCalculations.ViewModels
{
	public class ChartsPanelControlViewModel
	{

		public ISeries[] Series { get; set; }
			= new ISeries[]
			{
				new LineSeries<int>
				{
					Values = new int[] { 4, 6, 5, 3, -3, -1, 2 },
					Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
					Fill = null,
					GeometryFill = null,
					GeometryStroke = new SolidColorPaint(SKColors.DarkBlue){StrokeThickness=5},
					GeometrySize = 2,
				},
			};
	}
}
