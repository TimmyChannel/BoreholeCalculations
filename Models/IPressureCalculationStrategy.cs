using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models
{
	public interface IPressureCalculationStrategy
	{
		Task<double[]> CalculatePressureArray(double depth, double numSteps, double rhoSurface, CancellationToken cancellationToken);
	}

}
