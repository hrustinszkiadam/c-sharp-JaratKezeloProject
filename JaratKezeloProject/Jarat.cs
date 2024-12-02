using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
	public class Jarat
	{
		public string jaratSzam { get; set; }
		public string honnanRepter { get; set; }
		public string hovaRepter { get; set; }
		public DateTime indulas { get; set; }
		public TimeSpan keses { get; set; }

		public Jarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas)
		{
			if (string.IsNullOrEmpty(jaratSzam)) throw new ArgumentNullException("A járat szám nem lehet üres!", nameof(jaratSzam));
			if (string.IsNullOrEmpty(honnanRepter)) throw new ArgumentNullException("A járat szám nem lehet üres!", nameof(honnanRepter));
			if (string.IsNullOrEmpty(hovaRepter)) throw new ArgumentNullException("A járat szám nem lehet üres!", nameof(hovaRepter));

			this.jaratSzam = jaratSzam;
			this.honnanRepter = honnanRepter;
			this.hovaRepter = hovaRepter;
			this.indulas = indulas;
			this.keses = TimeSpan.Zero;
		}
	}
}
