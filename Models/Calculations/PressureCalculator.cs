﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models.Calculations
{
	public class PressureCalculator
	{
		private IPressureCalculationStrategy _pressureCalculationStrategy;

		public void SetPressureCalculationStrategy(IPressureCalculationStrategy strategy)
		{
			_pressureCalculationStrategy = strategy;
		}
		public Task<double[]> CalculatePressureArray(double depth, double numSteps, double rhoSurface, CancellationToken cancellationToken)
		{
			return _pressureCalculationStrategy.CalculatePressureArray(depth, numSteps, rhoSurface, cancellationToken);
		}

	}
}
