using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models.Data
{
	public interface IBoreholeRepository
	{
		void Add(IBorehole well);
		IBorehole GetById(int id);
		IEnumerable<IBorehole> GetAll();
		void Update(IBorehole well);
		void Delete(int id);
	}
}
