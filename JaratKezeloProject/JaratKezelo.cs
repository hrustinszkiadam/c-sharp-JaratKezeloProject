using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
	public class JaratKezelo
	{
		private List<Jarat> jaratok;

		public JaratKezelo()
		{
			jaratok = new List<Jarat>();
		}

		public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
		{
			Jarat ujJarat = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);

			if (jaratok.Exists(j => j.jaratSzam == jaratSzam)) throw new ArgumentException("A járat már létezik!", nameof(ujJarat));

			jaratok.Add(ujJarat);
		}

		public void Keses(string jaratSzam, TimeSpan keses)
		{
			if (string.IsNullOrEmpty(jaratSzam)) throw new ArgumentNullException("A járat szám nem lehet üres!", nameof(jaratSzam));

			var jarat = jaratok.Find(j => j.jaratSzam == jaratSzam);
			if (jarat == null) throw new ArgumentException("Nincs ilyen járat!", nameof(jaratSzam));

			if (jarat.keses + keses < TimeSpan.Zero) throw new NegativKesesException();


			jarat.keses += keses;
		}

		public DateTime MikorIndul(string jaratSzam)
		{
			if (string.IsNullOrEmpty(jaratSzam)) throw new ArgumentNullException("A járat szám nem lehet üres!", nameof(jaratSzam));
			var jarat = jaratok.Find(j => j.jaratSzam == jaratSzam);
			if (jarat == null) throw new ArgumentException("Nincs ilyen járat!", nameof(jaratSzam));


			return jarat.indulas + jarat.keses;
		}

		public List<string> JaratokRepuloterrol(string repter)
		{
			if (string.IsNullOrEmpty(repter)) throw new ArgumentNullException("A reptér nem lehet üres", nameof(repter));

			return jaratok.FindAll(j => j.honnanRepter == repter).Select(j => j.jaratSzam).ToList();
		}

	}
}
