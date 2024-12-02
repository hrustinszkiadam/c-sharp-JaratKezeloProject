using JaratKezeloProject;

namespace TestJaratKezeloProject
{
	public class Tests
	{
		JaratKezelo jaratkezelo;

		[SetUp]
		public void Setup()
		{
			jaratkezelo = new JaratKezelo();
		}

		[Test]
		public void Test1()
		{
			Assert.Pass();
		}
	}
}