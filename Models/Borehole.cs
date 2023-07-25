using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BoreholeCalculations.Models.Calculations;
using System.Threading;

namespace BoreholeCalculations.Models
{
	public class Borehole : ObservableObject, IBorehole
	{
		string _name;
		int _id;
		double _depth;
		double _averageLiquidDensity;
		Point _coordinates;
		Dictionary<double, double> _pressureByDepth;
		public int ID => _id;
		public string Name { get => _name; set => SetProperty(ref _name, value); }
		public double Depth { get => _depth; set => SetProperty(ref _depth, value); }
		public Point Coordinates => _coordinates;
		public Dictionary<double, double> PressureByDepth { get => _pressureByDepth; set => SetProperty(ref _pressureByDepth, value); }

		public double AverageLiquidDensity { get => _averageLiquidDensity; set => SetProperty(ref _averageLiquidDensity, value); }

		public Borehole(string name, int id, double depth, Point coordinates, double avgLiquidDensity)
		{
			_name = name;
			_id = id;
			_depth = depth;
			_coordinates = coordinates;
			_pressureByDepth = new Dictionary<double, double>();
			_averageLiquidDensity = avgLiquidDensity;
		}

	}
}
