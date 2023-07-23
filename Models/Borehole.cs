using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoreholeCalculations.Models
{
	public class Borehole : ObservableObject, IBorehole
	{
		string _name;
		int _id;
		double _depth;
		Point _coordinates;
		Dictionary<double, double> _pressureByDepth;
		public string Name { get => _name; set => SetProperty(ref _name, value); }
		public int ID => _id;
		public double Depth { get => _depth; set => SetProperty(ref _depth, value); }
		public Point Coordinates => _coordinates;
		public Dictionary<double, double> PressureByDepth => new Dictionary<double, double>(_pressureByDepth);
		public Borehole(string name, int id, double depth, Point coordinates)
		{
			_name = name;
			_id = id;
			_depth = depth;
			_coordinates = coordinates;
			_pressureByDepth = new Dictionary<double, double>();
		}
		public void
	}
}
