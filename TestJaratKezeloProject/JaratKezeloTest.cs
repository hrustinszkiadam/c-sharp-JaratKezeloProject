using JaratKezeloProject;

namespace TestJaratKezeloProject
{
	public class Tests
	{
		JaratKezelo kezelo;

		[SetUp]
		public void Setup()
		{
			kezelo = new JaratKezelo();
		}

		#region UjJarat
		[Test]
		public void UjJarat_ErvenyesAdatokkal()
		{
			kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));

			Assert.That(kezelo.Jaratok.Count, Is.EqualTo(1));
		}

		[Test]
		public void UjJarat_Duplikalt_ArgumentExceptiontDob()
		{
			kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));

			Assert.Throws<ArgumentException>(() => kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0)));
		}

		[Test]
		public void UjJarat_JaratSzamUres_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.UjJarat("", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0)));
		}

		[Test]
		public void UjJarat_RepterHonnanUres_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.UjJarat("PC333", "", "BUD", new DateTime(2024, 11, 30, 9, 25, 0)));
		}

		[Test]
		public void UjJarat_RepterHovaUres_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.UjJarat("PC333", "IST SAW", "", new DateTime(2024, 11, 30, 9, 25, 0)));
		}

		[Test]
		public void UjJarat_JaratSzamNull_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.UjJarat(null, "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0)));
		}

		[Test]
		public void UjJarat_RepterHonnanNull_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.UjJarat("PC333", null, "BUD", new DateTime(2024, 11, 30, 9, 25, 0)));
		}

		[Test]
		public void UjJarat_RepterHovaNull_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.UjJarat("PC333", "IST SAW", null, new DateTime(2024, 11, 30, 9, 25, 0)));
		}
		#endregion

		#region Keses
		[Test]
		public void Keses_ErvenyesAdatokkal()
		{
			kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));

			kezelo.Keses("PC333", TimeSpan.FromMinutes(10));
			kezelo.Keses("PC333", TimeSpan.FromMinutes(-5));

			Assert.That(kezelo.Jaratok.Find(j => j.jaratSzam == "PC333")!.keses, Is.EqualTo(TimeSpan.FromMinutes(5)));
		}

		[Test]
		public void Keses_NegativKesesExceptiontDob()
		{
			kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));

			Assert.Throws<NegativKesesException>(() => kezelo.Keses("PC333", TimeSpan.FromMinutes(-10)));
		}

		[Test]
		public void Keses_NincsIlyenJarat_ArgumentExceptiontDob()
		{
			Assert.Throws<ArgumentException>(() => kezelo.Keses("PC333", TimeSpan.FromMinutes(10)));
		}

		[Test]
		public void Keses_JaratSzamUres_ArgumentNullExceptiontDob()
		{
			kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));

			Assert.Throws<ArgumentNullException>(() => kezelo.Keses("", TimeSpan.FromMinutes(10)));
		}

		[Test]
		public void Keses_JaratSzamNull_ArgumentNullExceptiontDob()
		{
			kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));

			Assert.Throws<ArgumentNullException>(() => kezelo.Keses(null, TimeSpan.FromMinutes(10)));
		}
		#endregion

		#region MikorIndul
		[Test]
		public void MikorIndul_ErvenyesAdatokkal()
		{
			kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));

			Assert.That(kezelo.MikorIndul("PC333"), Is.EqualTo(new DateTime(2024, 11, 30, 9, 25, 0)));
		}

		[Test]
		public void MikorIndul_NincsIlyenJarat_ArgumentExceptiontDob()
		{
			Assert.Throws<ArgumentException>(() => kezelo.MikorIndul("PC333"));
		}

		[Test]
		public void MikorIndul_JaratSzamUres_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.MikorIndul(""));
		}

		[Test]
		public void MikorIndul_JaratSzamNull_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.MikorIndul(null));
		}
		#endregion

		#region JaratokRepuloterrol
		[Test]
		public void JaratokRepuloterrol_ErvenyesAdatokkal()
		{
			kezelo.UjJarat("PC333", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));
			kezelo.UjJarat("PC444", "IST SAW", "BUD", new DateTime(2024, 11, 30, 9, 25, 0));
			kezelo.UjJarat("PC555", "BUD", "IST SAW", new DateTime(2024, 11, 30, 9, 25, 0));

			Assert.That(kezelo.JaratokRepuloterrol("IST SAW"), Is.EquivalentTo(new List<string> { "PC333", "PC444" }));
		}

		[Test]
		public void JaratokRepuloterrol_NincsenekIlyenJaratok()
		{
			Assert.That(kezelo.JaratokRepuloterrol("IST SAW"), Is.Empty);
		}

		[Test]
		public void JaratokRepuloterrol_RepterUres_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.JaratokRepuloterrol(""));
		}

		[Test]
		public void JaratokRepuloterrol_RepterNull_ArgumentNullExceptiontDob()
		{
			Assert.Throws<ArgumentNullException>(() => kezelo.JaratokRepuloterrol(null));
		}
		#endregion
	}
}