using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BoreholeCalculations.Models
{
	public interface IBorehole
	{
		string Name { get; }
		int ID { get; }
		Double Depth { get; }
		Point Coordinates { get; }
	}
}
