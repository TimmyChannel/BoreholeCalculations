using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models.Calculations
{
	public class SimplePressureCalculationStrategy : IPressureCalculationStrategy
	{
		const double g = 9.81; 

		public async Task<double[]> CalculatePressureArray(double depth, double numSteps, double rhoSurface, CancellationToken cancellationToken)
			=> await Task.Run(() =>
			{
				double[] result = new double[(int)numSteps];
				double stepSize = depth / numSteps;
				for (int i = 0; i < numSteps; i++)
				{
					cancellationToken.ThrowIfCancellationRequested(); 
					double currentDepth = (i + 0.5) * stepSize;
					double currentPressure = rhoSurface * g * currentDepth;
					result[i] = currentPressure;
				}
				return result;
			}, cancellationToken);

	}
}
